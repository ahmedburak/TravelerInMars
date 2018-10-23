using System;
using System.Collections.Generic;
using TravelerInMars.DTO;
using TravelerInMars.Service;

namespace TravelerInMars.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("Lütfen yüzeyin sağ üst köşe koordinatlarını giriniz");
                var maxXandY = System.Console.ReadLine();

                var TravelerValues = new List<TravelerDTO>();
                for (var i = 1; i <= 2; i++)
                {
                    System.Console.WriteLine($"Lütfen {i}. ajanın ilk konumunu giriniz");
                    var coordinates = System.Console.ReadLine();

                    System.Console.WriteLine($"Lütfen {i}. ajanın komutlarını giriniz");
                    var commands = System.Console.ReadLine();

                    TravelerValues.Add(new TravelerDTO
                    {
                        Commands = commands,
                        FirstCoordinates = coordinates
                    });
                }

                using (TravelerService service = new TravelerService())
                {
                    var result = service.CalculateTravelersCoordinates(maxXandY, TravelerValues, out string errorMessage);

                    System.Console.Clear();

                    if (result == null)
                    {
                        System.Console.WriteLine(errorMessage);
                    }
                    else
                    {
                        result.ForEach(System.Console.WriteLine);
                    }

                    WriteMessage();
                }
            }
            catch (Exception ex)
            {
                WriteMessage(ex);
            }

        }


        // private 
        private static void WriteMessage(Exception ex = null)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(ex != null ? ex.Message : "Çıkmak için Enter tuşuna basınız");
            System.Console.ReadLine();
        }

        private static void WriteMessage(string message)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(message != null ? message : "Çıkmak için Enter tuşuna basınız");
            System.Console.ReadLine();
        }
    }
}