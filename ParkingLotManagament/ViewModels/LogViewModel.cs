using ParkingLotManagament.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        [DisplayName("Subscription")]
        public int SubscriptionId { get; set; }
        [DisplayName("Check-in Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckInTime { get; set; }
        [DisplayName("Check-out Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckOutTime { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Subscription")]
        public virtual Subscription Subscription { get; set; } = null!;
    }
}
