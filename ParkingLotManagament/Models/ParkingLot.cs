using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.Models
{
    public partial class ParkingLot
    {
        public int Id { get; set; }
        public string ParkingName { get; set; } = null!;
        public int? SubscriptionId { get; set; }
        public virtual Subscription? Subscription { get; set; }
    }
}
