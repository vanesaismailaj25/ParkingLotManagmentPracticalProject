using System.ComponentModel;

namespace ParkingLotManagament.ViewModels
{
    public class PricingPlanViewModel
    {
        [DisplayName("Hourly Pricing")]
        public decimal HourlyPricing { get; set; }
        [DisplayName("Daily Pricing")]
        public decimal DailyPricing { get; set; }
    }
}
