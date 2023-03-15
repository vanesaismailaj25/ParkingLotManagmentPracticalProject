using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriberViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;
        [Required]
        [DisplayName("Id Number")]
        public string IdCardNumber { get; set; } = null!;
        [EmailAddress]
        [DisplayName("E-mail")]
        public string? Email { get; set; }
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = null!;
        [DataType(DataType.DateTime)]
        [DisplayName("Birthday")]
        public DateTime? Birthday { get; set; }
        [DisplayName("Plate Number")]
        public string PlateNumber { get; set; } = null!;

    }
}
