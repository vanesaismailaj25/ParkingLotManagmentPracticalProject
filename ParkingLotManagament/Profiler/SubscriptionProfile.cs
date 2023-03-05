using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<SubscriptionViewModel, Subscriber>().ReverseMap();
        }
    }
}
