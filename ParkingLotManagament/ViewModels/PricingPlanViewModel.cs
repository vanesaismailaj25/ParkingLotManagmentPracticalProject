using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class PricingPlanViewModel
    {
        public int Id { get; set; }
        [DisplayName("Hourly Pricing")]
        public decimal HourlyPricing { get; set; }
        [DisplayName("Daily Pricing")]
        public decimal DailyPricing { get; set; }
        [DisplayName("Minimum Hours")]
        public TimeSpan MinimumHours { get; set; }
        public bool Weekend { get; set; }
        [DisplayName("Day of the week")]
        public string DayOfWeekName
        {
            get
            {
                if (Weekend)
                {
                    return "Weekend";
                }
                else
                {
                    return "Weekday";
                }
            }


        }
    }
}
