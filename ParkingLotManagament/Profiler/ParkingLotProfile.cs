using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            CreateMap<ParkingDetailsViewModel, ParkingLot>().ReverseMap();
           
        }
    }

}
