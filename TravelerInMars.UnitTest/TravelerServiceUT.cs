using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelerInMars.DTO;
using TravelerInMars.Service;

namespace TravelerInMars.UnitTest
{
    [TestClass]
    public class TravelerServiceUT
    {
        [TestMethod]
        public void CalculateTravelersCoordinates()
        {
            using (TravelerService service = new TravelerService())
            {
                var result = service.CalculateTravelersCoordinates("5 5", new List<TravelerDTO>
                {
                     new TravelerDTO
                     {
                           FirstCoordinates="1 2 N",
                           Commands="LMLMLMLMM"
                     },
                     new TravelerDTO
                     {
                           FirstCoordinates="3 3 E",
                           Commands="MMRMMRMRRM"
                     },
                }, out string errorMessage);

                if (result != null)
                {
                    Assert.IsTrue(result[0] == "1 3 N" && result[1] == "5 1 E");
                }
                else
                {
                    Assert.Fail(errorMessage);
                }
            }
        }
    }
}