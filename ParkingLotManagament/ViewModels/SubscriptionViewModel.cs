
using ParkingLotManagament.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriptionViewModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Subscriber Id")]
        public int SubscriberId { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Discount Value")]
        public decimal? DiscountValue { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Plate Number")]
        public string PlateNumber { get; set; }
        public virtual Subscriber Subscriber { get; set; }

    }

}
