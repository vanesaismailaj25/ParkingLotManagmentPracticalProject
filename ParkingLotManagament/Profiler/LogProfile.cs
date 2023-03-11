using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogViewModel,Log>().ReverseMap();
        }
    }
}
