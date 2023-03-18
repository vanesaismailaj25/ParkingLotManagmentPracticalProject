using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagament.ViewModels
{
    public class SubscriberViewModel
    {

        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; } = null!;
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
        [DisplayName("Identity Card Number")]
        [RegularExpression(@"^[A-Z]{1}[0-9]{8}[A-Z]{1}$", 
                            ErrorMessage="Entered Id Card format is not valid.")]
        public string IdCardNumber { get; set; } = null!;
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; } = null!;
        [DisplayName("Birthday")]
        public DateTime? Birthday { get; set; }
        [DisplayName("Plate Number")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{3}[A-Z]{2}$",
                            ErrorMessage = "Entered Plate Number format is not valid.")]
        public string PlateNumber { get; set; } = null!;

    }
}
