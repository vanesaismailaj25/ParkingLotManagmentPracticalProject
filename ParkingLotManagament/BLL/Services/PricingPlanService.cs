using AutoMapper;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services;

public class PricingPlanService : IPricingPlanService
{
    private readonly IPricingPlansRepository _repository;
    private readonly IMapper _mapper;

    public PricingPlanService(IPricingPlansRepository repository, IMapper mapper)
    {

       _repository = repository;
        _mapper = mapper;
    }

    public async Task<PricingPlanViewModel> UpdateAsync(PricingPlanViewModel planViewModel)
    {
        var mappedPricePlan = _mapper.Map<PricingPlan>(planViewModel);
        var planUpdate = await _repository.UpdateAsync(mappedPricePlan);
        var updatedMapped = _mapper.Map<PricingPlanViewModel>(planUpdate);
        return updatedMapped;
    }


    public async Task<IEnumerable<PricingPlanViewModel>> GetAll()
    {
        var result = await _repository.GetAllAsync();
        var mappedPlan=_mapper.Map<IEnumerable<PricingPlanViewModel>>(result);
        return mappedPlan;
    }

    public async Task<PricingPlanViewModel> GetPricing(int Id)
    {
        var result = await _repository.GetAsync(Id);
        var mappedPlan = _mapper.Map<PricingPlanViewModel>(result);
        return mappedPlan;
    }

    public async Task<PricingPlanViewModel> GetWeekEnd(bool day)
    {
        var result = await _repository.GetWeekEndAsync(day);
        var mappedPlan = _mapper.Map<PricingPlanViewModel>(result);
        return mappedPlan;
    }
}
