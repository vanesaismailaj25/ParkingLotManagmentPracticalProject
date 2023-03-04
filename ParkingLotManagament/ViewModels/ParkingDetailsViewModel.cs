using ParkingLotManagament.Models;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class ParkingDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Parking Name")]
        public string ParkingName { get; set; } = null!;
        [Display(Name ="Subscription")]
        public int? SubscriptionId { get; set; }
        public virtual Subscription? Subscription { get; set; }
        [Display(Name ="Is Reserved")]
        public bool IsReserved =>SubscriptionId.HasValue;
    }
}
