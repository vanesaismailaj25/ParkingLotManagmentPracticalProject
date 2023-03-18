using ParkingLotManagament.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class ParkingDetailsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Parking Name")]
        public string ParkingName { get; set; } = null!;
        [DisplayName("Subscription ID")]
        public int? SubscriptionId { get; set; }
        public virtual Subscription? Subscription { get; set; }
        [DisplayName("Is Reserved")]
        public bool IsReserved =>SubscriptionId.HasValue;
    }
}
