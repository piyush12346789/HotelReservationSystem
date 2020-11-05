using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Adding_Weekday_And_Weekend_RewardCustomerRates_And_Verifying()
        {
            Hotel lakeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 110,
                WeekendRateForRegularCustomer = 90,
                WeekdayRateForRewardCustomer = 80,
                WeekendRateForRewardCustomer = 80,
                Rating = 3
            };
            Hotel bridgeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 150,
                WeekendRateForRegularCustomer = 50,
                WeekdayRateForRewardCustomer = 110,
                WeekendRateForRewardCustomer = 50,
                Rating = 4
            };
            Hotel ridgeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 220,
                WeekendRateForRegularCustomer = 150,
                WeekdayRateForRewardCustomer = 100,
                WeekendRateForRewardCustomer = 40,
                Rating = 5
            };
            //checking for lakewood
            int expectedWeekdayRate = 80;
            int expectedWeekendRate = 80;
            int actualWeekdayRate = lakeWood.WeekdayRateForRewardCustomer;
            int actualWeekendRate = lakeWood.WeekendRateForRewardCustomer;
            Assert.AreEqual(expectedWeekendRate, actualWeekendRate);
            Assert.AreEqual(expectedWeekdayRate, actualWeekdayRate);
        }
    }
}
