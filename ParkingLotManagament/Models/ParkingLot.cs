using System;
using System.Collections.Generic;

namespace ParkingLotManagament.Models
{
    public partial class ParkingLot
    {
        public int Id { get; set; }
        public string ParkingName { get; set; } = null!;
        public bool IsReserved { get; set; }
        public int? SubscriptionId { get; set; }

        public virtual Subscription? Subscription { get; set; }
    }
}
