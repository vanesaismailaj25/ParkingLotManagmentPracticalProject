using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Signing;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services;

public class PricingPlanService : IPricingPlanService
{
    private readonly IPricingPlansRepository repository;

    public PricingPlanService(IPricingPlansRepository _repository)
    {
        repository = _repository ;
    }

    public async Task<List<PricingPlanViewModel>> GetAllAsync()
    {
        var result = await repository.GetAllAsync();
        var pricingPlan = result.Select(p => new PricingPlanViewModel
        {
            HourlyPricing = p.HourlyPricing,
            DailyPricing = p.DailyPricing
        }).ToList();

        return pricingPlan;
    }

    public async Task<PricingPlan> UpdateAsync(int Id,PricingPlan plan)
    {
        var planExists = await repository.GetAsync(Id);

        if (planExists != null) 
        {
            planExists.HourlyPricing = plan.HourlyPricing;
            planExists.DailyPricing = plan.DailyPricing;

            await repository.UpdateAsync(Id,plan);

            var planUpdate = await repository.GetAsync(Id);

            return planUpdate;
        }
        return null;
    }
}
