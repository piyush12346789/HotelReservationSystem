using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Adding_Weekday_And_Weekend_RewardCustomerRates_And_Verifying()
        {
            string expectedHotelName = "Ridgewood";
            int expectedRate = 140;
            int expectedRating = 5;
            string actualHotelName = Operation.FindCheapestBestRatedHotelName("11Sep2020", "12Sep2020", "Reward");
            int actualRate = Operation.FindCheapestHotelRate("11Sep2020", "12Sep2020", "Reward");
            int actualRating = Operation.GetRatingOfHotel(actualHotelName);
            Assert.AreEqual(expectedHotelName, actualHotelName);
            Assert.AreEqual(expectedRate, actualRate);
            Assert.AreEqual(expectedRating, actualRating);
        }
    }
}
