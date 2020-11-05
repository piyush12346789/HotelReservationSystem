using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Adding_Rating_To_Hotels_And_Verifying()
        {
            int expectedRating = 5;
            Hotel lakeWood = new Hotel
            {
                Rating = 3
            };
            Hotel bridgeWood = new Hotel
            {
                Rating = 4
            };
            Hotel ridgeWood = new Hotel
            {
                Rating = 5
            };
            int actualRating = ridgeWood.Rating;
            Assert.AreEqual(expectedRating, actualRating);
        }
    }
}
