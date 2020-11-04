using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Adding_Weekday_And_Weekend_RegularCustomerRates_And_Verifying()
        {
            Hotel lakeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 110,
                WeekendRateForRegularCustomer = 90
            };
            Hotel bridgeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 150,
                WeekendRateForRegularCustomer = 50
            };
            Hotel ridgeWood = new Hotel
            {
                WeekdayRateForRegularCustomer = 220,
                WeekendRateForRegularCustomer = 150
            };
            int expectedWeekDayRateforRegularCustomer = 110;
            int expectedWeekendRateforRegularCustomer = 90;
            Assert.AreEqual(expectedWeekDayRateforRegularCustomer, lakeWood.WeekdayRateForRegularCustomer);
            Assert.AreEqual(expectedWeekendRateforRegularCustomer, lakeWood.WeekendRateForRegularCustomer);
        }
    }
}
