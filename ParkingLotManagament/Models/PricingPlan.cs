using System;
using System.Collections.Generic;

namespace ParkingLotManagament.Models
{
    public partial class PricingPlan
    {
        public int Id { get; set; }
        public decimal HourlyPricing { get; set; }
        public decimal DailyPricing { get; set; }
        public TimeSpan MinimumHours { get; set; }
        public bool Weekend { get; set; }
    }
}
