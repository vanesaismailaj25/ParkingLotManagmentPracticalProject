using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface IPricingPlansRepository
    {
        Task<IEnumerable<PricingPlan>> GetAllAsync();
        Task<PricingPlan> GetAsync(int Id);
        Task<PricingPlan> UpdateAsync(PricingPlan pricingPlan);
        Task<PricingPlan> GetWeekEndAsync(bool day);
    }
}
