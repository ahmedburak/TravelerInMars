using System;
using System.Collections.Generic;
using System.Linq;
using TravelerInMars.DTO;

namespace TravelerInMars.Service
{
    public class TravelerService : IDisposable
    {
        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<string> CalculateTravelersCoordinates(string maxXandY, List<TravelerDTO> elements, out string errorMessage)
        {
            try
            {
                errorMessage = null;
                var splitList = maxXandY.Split(' ');
                var limit = new CoordinateDTO
                {
                    X = Convert.ToUInt16(splitList[0]),
                    Y = Convert.ToUInt16(splitList[1])
                };

                foreach (var item in elements)
                {
                    splitList = item.FirstCoordinates.Split(' ');

                    item.Coordinate = new CoordinateDTO
                    {
                        X = Convert.ToUInt16(splitList[0]),
                        Y = Convert.ToUInt16(splitList[1]),
                    };

                    item.Direction = Convert.ToChar(splitList[2]);

                    for (int i = 0; i < item.Commands.Length; i++)
                    {
                        var command = item.Commands[i];
                        switch (item.Commands[i])
                        {
                            case 'L':

                                if (item.Direction == 'N')
                                {
                                    item.Direction = 'W';
                                }
                                else if (item.Direction == 'W')
                                {
                                    item.Direction = 'S';
                                }
                                else if (item.Direction == 'S')
                                {
                                    item.Direction = 'E';
                                }
                                else // East
                                {
                                    item.Direction = 'N';
                                }
                                break;

                            case 'R':

                                if (item.Direction == 'N')
                                {
                                    item.Direction = 'E';
                                }
                                else if (item.Direction == 'E')
                                {
                                    item.Direction = 'S';
                                }
                                else if (item.Direction == 'S')
                                {
                                    item.Direction = 'W';
                                }
                                else // west
                                {
                                    item.Direction = 'N';
                                }
                                break;

                            case 'M':

                                if (item.Direction == 'N' && item.Coordinate.Y < limit.Y)
                                {
                                    item.Coordinate.Y++;
                                }
                                else if (item.Direction == 'E' && item.Coordinate.X < limit.X)
                                {
                                    item.Coordinate.X++;
                                }
                                else if (item.Direction == 'S' && item.Coordinate.Y > 0)
                                {
                                    item.Coordinate.Y--;
                                }
                                else if (item.Direction == 'W' && item.Coordinate.X > 0) // west
                                {
                                    item.Coordinate.X--;
                                }

                                break;
                        }
                    }
                }

                return elements.Select(x => x.ToString()).ToList();
            }
            catch (Exception ex)
            {
                if (ex.Message != null)
                {
                    errorMessage = ex.Message;
                }
                else
                {
                    errorMessage = "Bir hata oluştu!";
                }
                return null;
            }
        }
    }
}