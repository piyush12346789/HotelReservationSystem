using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Operation
    {
        private const string REWARD_CUSTOMER = "Reward";
        private const string REGULAR_CUSTOMER = "Regular";
        private const string LAKEWOOD = "Lakewood";
        private const string BRIDGEWOOD = "Bridgewood";
        private const string RIDGEWOOD = "Ridgewood";
        private const string SATURDAY = "Saturday";
        private const string SUNDAY = "Sunday";
        private static Hotel lakeWood = new Hotel
        {
            WeekdayRateForRegularCustomer = 110,
            WeekendRateForRegularCustomer = 90,
            WeekdayRateForRewardCustomer = 80,
            WeekendRateForRewardCustomer = 80,
            Rating = 3
        };
        private static Hotel bridgeWood = new Hotel
        {
            WeekdayRateForRegularCustomer = 150,
            WeekendRateForRegularCustomer = 50,
            WeekdayRateForRewardCustomer = 110,
            WeekendRateForRewardCustomer = 50,
            Rating = 4
        };
        private static Hotel ridgeWood = new Hotel
        {
            WeekdayRateForRegularCustomer = 220,
            WeekendRateForRegularCustomer = 150,
            WeekdayRateForRewardCustomer = 100,
            WeekendRateForRewardCustomer = 40,
            Rating = 5
        };
        private static int totalCost = 0;
        public static int GetMonthInDigits(string month)
        {
            switch (month.ToLower())
            {
                case "jan":
                    return 1;
                case "feb":
                    return 2;
                case "mar":
                    return 3;
                case "apr":
                    return 4;
                case "may":
                    return 5;
                case "jun":
                    return 6;
                case "jul":
                    return 7;
                case "aug":
                    return 8;
                case "sep":
                    return 9;
                case "oct":
                    return 10;
                case "nov":
                    return 11;
                case "dec":
                    return 12;
                default:
                    Console.WriteLine("Invalid Month");
                    return 0;
            }
        }
        public static string GetDay(string date)
        {
            int day = Convert.ToInt32(date.Substring(0, 2));
            string month = date.Substring(2, 3);
            int year = Convert.ToInt32(date.Substring(5));
            DateTime d = new DateTime(year, Operation.GetMonthInDigits(month), day);
            return d.DayOfWeek.ToString();
        }
        public static int GetLakewoodCost(string checkInDate, string checkOutDate, string customerType)
        {
            return GetHotelCost(checkInDate, checkOutDate, customerType, lakeWood);
        }
        public static int GetBridgewoodCost(string checkInDate, string checkOutDate, string customerType)
        {
            return GetHotelCost(checkInDate, checkOutDate, customerType, bridgeWood);
        }
        public static int GetRidgewoodCost(string checkInDate, string checkOutDate, string customerType)
        {
            return GetHotelCost(checkInDate, checkOutDate, customerType, ridgeWood);
        }
        public static int GetHotelCost(string checkInDate, string checkOutDate, string customerType, Hotel hotel)
        {
            totalCost = 0;
            List<string> listofdays = new List<string>
            {
                GetDay(checkInDate),
                GetDay(checkOutDate)
            };
            foreach (string day in listofdays)
            {
                switch (customerType)
                {
                    case REGULAR_CUSTOMER:
                        switch (day)
                        {
                            case SATURDAY:
                                totalCost += hotel.WeekendRateForRegularCustomer;
                                break;
                            case SUNDAY:
                                totalCost += hotel.WeekendRateForRegularCustomer;
                                break;
                            default:
                                totalCost += hotel.WeekdayRateForRegularCustomer;
                                break;
                        }
                        break;
                    case REWARD_CUSTOMER:
                        switch (day)
                        {
                            case SATURDAY:
                                totalCost += hotel.WeekendRateForRewardCustomer;
                                break;
                            case SUNDAY:
                                totalCost += hotel.WeekendRateForRewardCustomer;
                                break;
                            default:
                                totalCost += hotel.WeekdayRateForRewardCustomer;
                                break;
                        }
                        break;
                }
            }
            return totalCost;
        }
        public static int FindCheapestHotelRate(string checkInDate, string checkOutDate, string customerType)
        {
            int lakeWoodCost = GetLakewoodCost(checkInDate, checkOutDate, customerType);
            int bridgeWoodCost = GetBridgewoodCost(checkInDate, checkOutDate, customerType);
            int ridgeWoodCost = GetRidgewoodCost(checkInDate, checkOutDate, customerType);
            int leastCost = lakeWoodCost < bridgeWoodCost ? lakeWoodCost : bridgeWoodCost;
            leastCost = leastCost < ridgeWoodCost ? leastCost : ridgeWoodCost;
            return leastCost;
        }
        public static string FindCheapestHotelName(string checkInDate, string checkOutDate, string customerType)
        {
            int leastCost = FindCheapestHotelRate(checkInDate, checkOutDate, customerType);
            if (leastCost == GetLakewoodCost(checkInDate, checkOutDate, customerType))
            {
                if (leastCost == GetBridgewoodCost(checkInDate, checkOutDate, customerType))
                {
                    return LAKEWOOD + " and " + BRIDGEWOOD;
                }
                return LAKEWOOD;
            }
            else if (leastCost == GetBridgewoodCost(checkInDate, checkOutDate, customerType))
            {
                if (leastCost == GetRidgewoodCost(checkInDate, checkOutDate, customerType))
                {
                    return BRIDGEWOOD + " and " + RIDGEWOOD;
                }
                return BRIDGEWOOD;
            }
            else
            {
                if (leastCost == GetLakewoodCost(checkInDate, checkOutDate, customerType))
                {
                    return RIDGEWOOD + " and " + LAKEWOOD;
                }
                return RIDGEWOOD;
            }
        }
        public static int GetRatingOfHotel(string hotel)
        {
            switch (hotel)
            {
                case LAKEWOOD:
                    return lakeWood.Rating;
                case BRIDGEWOOD:
                    return bridgeWood.Rating;
                case RIDGEWOOD:
                    return ridgeWood.Rating;
                default:
                    return 0;
            }
        }
        public static string FindCheapestBestRatedHotelName(string checkInDate, string checkOutDate, string customerType)
        {
            string hotelName = FindCheapestHotelName(checkInDate, checkOutDate, customerType);
            if (hotelName.Contains("and"))
            {
                string[] hotels = hotelName.Split(" and ");
                int rating1 = GetRatingOfHotel(hotels[0]);
                int rating2 = GetRatingOfHotel(hotels[1]);
                if (rating1 > rating2)
                {
                    return hotels[0];
                }
                else
                {
                    return hotels[1];
                }
            }
            else
            {
                return hotelName;
            }
        }
        public static int FindBestRatedHotelRate(string checkInDate, string checkOutDate, string customerType)
        {
            int lakewoodRating = GetRatingOfHotel(LAKEWOOD);
            int bridgewoodRating = GetRatingOfHotel(BRIDGEWOOD);
            int ridgewoodRating = GetRatingOfHotel(RIDGEWOOD);
            int maxRating = lakewoodRating > bridgewoodRating ? lakewoodRating : bridgewoodRating;
            maxRating = maxRating > ridgewoodRating ? maxRating : ridgewoodRating;
            if (maxRating == lakewoodRating)
            {
                return GetRidgewoodCost(checkInDate, checkOutDate, customerType);
            }
            else if (maxRating == bridgewoodRating)
            {
                return GetBridgewoodCost(checkInDate, checkOutDate, customerType);
            }
            else
            {
                return GetLakewoodCost(checkInDate, checkOutDate, customerType);
            }
        }
        public static string FindBestRatedHotelName(string checkInDate, string checkOutDate, string customerType)
        {
            int cost = FindBestRatedHotelRate(checkInDate, checkOutDate, customerType);
            if (cost == GetRidgewoodCost(checkInDate, checkOutDate, customerType))
            {
                return RIDGEWOOD;
            }
            else if (cost == GetBridgewoodCost(checkInDate, checkOutDate, customerType))
            {
                return BRIDGEWOOD;
            }
            else
            {
                return LAKEWOOD;
            }
        }
    }
}