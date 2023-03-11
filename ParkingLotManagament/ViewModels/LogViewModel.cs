using ParkingLotManagament.Models;

namespace ParkingLotManagament.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public decimal Price { get; set; }

        public virtual Subscription Subscription { get; set; } = null!;
    }
}
