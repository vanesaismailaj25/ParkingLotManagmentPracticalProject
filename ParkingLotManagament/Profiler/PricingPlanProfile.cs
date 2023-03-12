using AutoMapper;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Profiler
{
    public class PricingPlanProfile : Profile
    {
        public PricingPlanProfile()
        {
            CreateMap<PricingPlanViewModel, PricingPlan>().ReverseMap();
        }
    }
}
