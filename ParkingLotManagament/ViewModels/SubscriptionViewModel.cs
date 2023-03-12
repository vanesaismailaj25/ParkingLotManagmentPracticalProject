using ParkingLotManagament.Models;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriptionViewModel
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlateNumber { get; set; }

        public virtual Subscriber Subscriber { get; set; }

    }

}
