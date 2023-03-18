using ParkingLotManagament.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriptionViewModel
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("Discount Value")]
        public decimal? DiscountValue { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [DisplayName("Plate Number")]
        public string PlateNumber { get; set; }
        [DisplayName("Subscriber ID")]
        public virtual Subscriber Subscriber { get; set; }

    }

}
