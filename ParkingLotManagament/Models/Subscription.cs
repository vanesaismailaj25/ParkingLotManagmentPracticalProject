using System;
using System.Collections.Generic;

namespace ParkingLotManagament.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            Logs = new HashSet<Log>();
            ParkingLots = new HashSet<ParkingLot>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int SubscriberId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Subscriber Subscriber { get; set; } = null!;
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
    }
}
