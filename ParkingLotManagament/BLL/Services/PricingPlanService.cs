using AutoMapper;
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

    public async Task<decimal> CalculateMonthlySubscriptionAsync(DateTime startDate, DateTime endDate)
    {
        // Step 1: Calculate the total number of days between the start and end dates
        int totalDays = (int)(endDate - startDate).TotalDays + 1;

        // Step 2: Calculate the number of weekdays and weekends in the total number of days
        int weekdays = 0;
        int weekends = 0;
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                weekdays++;
            }
            else
            {
                weekends++;
            }
        }

        // Step 3: Retrieve the pricing information for weekdays and weekends
        var weekdayPriceTask = await GetPricing(1);
        var weekendPriceTask = await GetPricing(2);

        // Step 4: Wait for the pricing information tasks to complete
        var weekdayPrice = weekdayPriceTask;
        var weekendPrice = weekendPriceTask;

        // Step 5: Multiply the number of weekdays by the weekday daily price
        decimal weekdayCost = weekdays * ((int)weekdayPrice.DailyPricing);

        // Step 6: Multiply the number of weekends by the weekend daily price
        decimal weekendCost = weekends * ((int)weekendPrice.DailyPricing);

        // Step 7: Add the weekday and weekend costs together to get the total monthly subscription cost
        decimal totalCost = weekdayCost + weekendCost;

        // Round up to the nearest cent
        return Math.Round(totalCost, 2, MidpointRounding.AwayFromZero);
    }

}
