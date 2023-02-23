using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface IPricingPlansRepository
    {
        Task<List<PricingPlan>> GetAllAsync();
        Task<PricingPlan> GetAsync(int Id);
        Task<PricingPlan> UpdateAsync(int Id,PricingPlan pricingPlan);
    }
}
