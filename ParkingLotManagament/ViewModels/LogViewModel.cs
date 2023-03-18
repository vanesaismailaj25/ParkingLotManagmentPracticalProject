using ParkingLotManagament.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public int? SubscriptionId { get; set; }
        [DisplayName("Check in Time")]
        public DateTime CheckInTime { get; set; }
        [DisplayName("Check out Time")]
        public DateTime? CheckOutTime { get; set; }
        [DisplayName("Price")]
        public decimal? Price { get; set; }
        [DisplayName("Subscription ID")]
        public virtual Subscription? Subscription { get; set; } = null!;
    }

    public partial class Log
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string PlateNumber { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public decimal? Price { get; set; }

        public virtual Subscription? Subscription { get; set; } = null!;
    }
}



}
