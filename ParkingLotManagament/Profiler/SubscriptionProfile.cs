using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionViewModel>().ForMember(
                dest => dest.PlateNumber,
                opt => opt.MapFrom(src => src.Subscriber.PlateNumber));
            CreateMap<SubscriptionViewModel, Subscription>();
        }
    }
}
