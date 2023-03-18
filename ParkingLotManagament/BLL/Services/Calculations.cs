using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;

namespace ParkingLotManagament.BLL.Services
{
    public class Calculations
    {

        public static decimal CalculateMonthlySubscription(DateTime startDate, DateTime endDate, decimal weekdayPrice, decimal weekendPrice)
        {
            //Calculate the total number of days between the start and end dates
            int totalDays = (int)(endDate - startDate).TotalDays + 1;

            //Calculate the number of weekdays and weekends in the total number of days
            int weekdays = 0;
            int weekends = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekdays++;
                }
                else
                {
                    weekends++;
                }
            }

            decimal weekdayCost = weekdays * (weekdayPrice);

            //Multiply the number of weekends by the weekend daily price
            decimal weekendCost = weekends * (weekendPrice);

            //Add the weekday and weekend costs together to get the total monthly subscription cost
            decimal totalCost = weekdayCost + weekendCost;

            //Round up to the nearest cent
            return Math.Round(totalCost, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalculateAmount(decimal price, decimal discountValue)
        {
            decimal amount = 0;
            amount = price - (discountValue * price/100);
            return amount;
        }

    }
}
