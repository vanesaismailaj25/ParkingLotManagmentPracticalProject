using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class PricingPlanViewModel
    {
        public int Id { get; set; }
        public decimal HourlyPricing { get; set; }
        public decimal DailyPricing { get; set; }
        public TimeSpan MinimumHours { get; set; }
        public bool Weekend { get; set; }
        [Display(Name = "Day of Week name")]
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
