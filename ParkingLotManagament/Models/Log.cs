using System;
using System.Collections.Generic;

namespace ParkingLotManagament.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public decimal Price { get; set; }

        public virtual Subscription? Subscription { get; set; }
    }
}
