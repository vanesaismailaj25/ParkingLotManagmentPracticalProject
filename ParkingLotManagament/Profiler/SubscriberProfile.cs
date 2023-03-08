using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class SubscriberProfile:Profile
    {
        public SubscriberProfile()
        {
            CreateMap<SubscriberViewModel,Subscriber>().ReverseMap();
        }

    }
}
