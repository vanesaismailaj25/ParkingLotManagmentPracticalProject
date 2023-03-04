using AutoMapper;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _repository;
        private readonly IMapper _mapper;
        public ParkingLotService(IParkingLotRepository parkingLot, IMapper mapper)
        {
            _repository = parkingLot ?? throw new ArgumentNullException(nameof(parkingLot));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        public IParkingLotRepository Get_repository()
        {
            return _repository;
        }

        public async Task<ParkingDetailsViewModel> Edit(ParkingDetailsViewModel parkingView)
        {
            var mappedparkingLot = _mapper.Map<ParkingLot>(parkingView);

            var updatedParkingLot = await _repository.Edit(mappedparkingLot);

            var updatedParkingView = _mapper.Map<ParkingDetailsViewModel>(updatedParkingLot);

            return updatedParkingView;
        }


        public async Task<IEnumerable<ParkingDetailsViewModel>> GetAll()
        {
            var result = await _repository.GetAll();
            var mappedParkingLot =  _mapper.Map<IEnumerable<ParkingDetailsViewModel>>(result);
            return mappedParkingLot;
        }

        public async Task<ParkingDetailsViewModel> GetById(int id)
        {
            var result = await _repository.Get(id);
            var mappedParkingLot = _mapper.Map<ParkingDetailsViewModel>(result);
            return mappedParkingLot;

        }

        public async Task<ParkingTableViewModel> CountAll()
        {
            var totalSpots = CountSpots();
            var reservedSpots = CountReservedSpots();
            var freeSpots = totalSpots - reservedSpots;

            var viewModel = new ParkingTableViewModel
            {
                TotalSpots = totalSpots,
                ReservedSpots = reservedSpots,
                FreeSpots = freeSpots
            };
            return viewModel;
        }
    }
}
