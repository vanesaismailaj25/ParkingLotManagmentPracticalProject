using ParkingLotManagament.Models;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel()
        {
            Logs = new HashSet<Log>();
            ParkingLots = new HashSet<ParkingLot>();
        }

        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Subscriber Subscriber { get; set; } = null!;
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<ParkingLot> ParkingLots { get; set; }

    }

}
