using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerInMars.DTO;
using TravelerInMars.Service;

namespace TravelerInMars.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Lütfen yüzeyin sağ üst köşe koordinatlarını giriniz");
                var maxXandY = Console.ReadLine();

                var TravelerValues = new List<TravelerDTO>();
                for (var i = 1; i <= 2; i++)
                {
                    Console.WriteLine($"Lütfen {i}. ajanın ilk konumunu giriniz");
                    var coordinates = Console.ReadLine();

                    Console.WriteLine($"Lütfen {i}. ajanın komutlarını giriniz");
                    var commands = Console.ReadLine();

                    TravelerValues.Add(new TravelerDTO
                    {
                        Commands = commands,
                        FirstCoordinates = coordinates
                    });
                }

                using (TravelerService service = new TravelerService())
                {
                    var result = service.CalculateTravelersCoordinates(maxXandY, TravelerValues, out string errorMessage);

                    Console.Clear();

                    if (result == null)
                    {
                        Console.WriteLine(errorMessage);
                    }
                    else
                    {
                        result.ForEach(Console.WriteLine);
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
            Console.WriteLine();
            Console.WriteLine(ex != null ? ex.Message : "Çıkmak için Enter tuşuna basınız");
            Console.ReadLine();
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message != null ? message : "Çıkmak için Enter tuşuna basınız");
            Console.ReadLine();
        }
    }
}