using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_DateRange_Should_Return_CheapestHotel()
        {
            string expectedHotelName = "Lakewood";
            int expectedHotelRate = 220;
            string actualHotelName = Operation.FindCheapestHotelName("10Sep2020", "11Sep2020");
            int actualHotelRate = Operation.FindCheapestHotelRate("10Sep2020", "11Sep2020");
            Assert.AreEqual(expectedHotelName, actualHotelName);
            Assert.AreEqual(expectedHotelRate, actualHotelRate);
        }
    }
}
