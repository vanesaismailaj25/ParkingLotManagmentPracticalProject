using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.IServices
{
    public interface IParkingLotService
    {
        int CountReservedSpots();
        int CountSpots();
        Task<ParkingLot> Edit(ParkingLot parkingLot);
        Task<IEnumerable<ParkingLot>> GetAll();
    }
}
