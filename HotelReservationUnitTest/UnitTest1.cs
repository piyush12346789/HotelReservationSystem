using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_Date_Range_Including_Weekend_Should_Return_Cheapest_Hotel()
        {
            int expectedHotelRate = 200;
            string expectedHotelName = "Lakewood and Bridgewood";
            int actualHotelRate = Operation.FindCheapestHotelRate("11Sep2020", "12Sep2020");
            string actualHotelName = Operation.FindCheapestHotelName("11Sep2020", "12Sep2020");
            Assert.AreEqual(expectedHotelRate, actualHotelRate);
            Assert.AreEqual(expectedHotelName, actualHotelName);
        }
    }
}
