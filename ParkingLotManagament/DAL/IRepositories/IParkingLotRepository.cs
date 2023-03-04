using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface IParkingLotRepository
    {
        Task<IEnumerable<ParkingLot>> GetAll();
        Task<ParkingLot> Get(int? id);
        Task<ParkingLot> Edit(ParkingLot parkingLot);
        Task<int> Count();
        Task<int> CountReserved();



    }
}
