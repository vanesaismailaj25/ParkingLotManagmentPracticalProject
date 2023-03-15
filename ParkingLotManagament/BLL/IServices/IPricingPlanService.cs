using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices
{
    public interface IPricingPlanService
    {
        Task<PricingPlanViewModel> UpdateAsync(PricingPlanViewModel planViewModel);
        Task<IEnumerable<PricingPlanViewModel>> GetAll();
        Task<PricingPlanViewModel> GetPricing(int Id);
        Task<decimal> CalculateMonthlySubscriptionAsync(DateTime startDate, DateTime endDate);

    }
}
