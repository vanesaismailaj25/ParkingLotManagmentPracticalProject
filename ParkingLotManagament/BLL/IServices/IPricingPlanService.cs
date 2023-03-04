using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices
{
    public interface IPricingPlanService
    {
        Task<PricingPlan> UpdateAsync(PricingPlan plan);
        Task<IEnumerable<PricingPlan>> GetAllAsync();
        Task<PricingPlan> GetPricing(int Id);
    }
}
