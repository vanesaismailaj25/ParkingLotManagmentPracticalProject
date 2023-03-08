using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _repository;
        public ParkingLotService(IParkingLotRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public int CountSpots()
        {
            var spots = _repository.Count().Result;
            return spots;
        }

        public int CountReservedSpots()
        {
            return _repository.CountReserved().Result;
        }

        public async Task<ParkingLot> Edit(ParkingLot parkingLot)
        {
            return await _repository.Edit(parkingLot);
        }

        public async Task<IEnumerable<ParkingLot>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
