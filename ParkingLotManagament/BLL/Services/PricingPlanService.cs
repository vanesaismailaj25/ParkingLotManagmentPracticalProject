using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services;

public class PricingPlanService : IPricingPlanService
{
    private readonly IPricingPlansRepository _repository;

    public PricingPlanService(IPricingPlansRepository repository)
    {

       _repository = repository;
    }

    public async Task<PricingPlan> UpdateAsync(PricingPlan plan)
    {
        var planUpdate = await _repository.UpdateAsync(plan);
        return planUpdate;
    }


    public async Task<IEnumerable<PricingPlan>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PricingPlan> GetPricing(int Id)
    {
        return await _repository.GetAsync(Id);
    }
}
