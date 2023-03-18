using System.ComponentModel;

namespace ParkingLotManagament.ViewModels
{
    public class ParkingTableViewModel
    {
        [DisplayName("Total Spots")]
        public int TotalSpots { get; set; }
        [DisplayName("Reserved Spots")]
        public int ReservedSpots { get; set; }
        [DisplayName("Free Spots")]
        public int FreeSpots { get; set; }

    }
}
