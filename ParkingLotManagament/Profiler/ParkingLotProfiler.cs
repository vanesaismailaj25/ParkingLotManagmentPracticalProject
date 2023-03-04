using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class ParkingLotProfiler : Profile
    {
        public ParkingLotProfiler()
        {
            CreateMap<ParkingDetailsViewModel, ParkingLot>().ReverseMap();
           
        }
    }

}
