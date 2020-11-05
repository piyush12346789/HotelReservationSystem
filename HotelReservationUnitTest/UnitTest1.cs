using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_Date_Range_Should_Return_Cheapest_BestRated_Hotel()
        {
            string expectedHotelName = "Bridgewood";
            int expectedRate = 200;
            string actualHotelName = Operation.FindCheapestBestRatedHotelName("11Sep2020", "12Sep2020");
            int actualRate = Operation.FindCheapestHotelRate("11Sep2020", "12Sep2020");
            Assert.AreEqual(expectedRate, actualRate);
            Assert.AreEqual(expectedHotelName, actualHotelName);
        }
    }
}
