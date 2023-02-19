using System;
using System.Collections.Generic;

namespace ParkingLotManagament.Models
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string PlateNumber { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
