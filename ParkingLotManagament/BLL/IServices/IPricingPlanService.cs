using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices
{
    public interface IPricingPlanService
    {
        Task<PricingPlan> UpdateAsync(int Id,PricingPlan plan);
        Task<IEnumerable<PricingPlan>> GetAllAsync();
    }
}
