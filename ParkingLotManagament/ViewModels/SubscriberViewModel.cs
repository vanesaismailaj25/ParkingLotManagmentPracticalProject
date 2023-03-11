namespace ParkingLotManagament.ViewModels
{
    public class SubscriberViewModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string PlateNumber { get; set; } = null!;

    }
}
