using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories;

public class PricingPlanRepository : IPricingPlansRepository
{
    ParkingLotManagementDatabaseContext _context;

    public PricingPlanRepository(ParkingLotManagementDatabaseContext context)
    {
        _context = context;
    }

    public async Task<PricingPlan> GetAsync(int Id)
    {
        var pricingPlan = await _context.PricingPlans.FindAsync(Id);
        return pricingPlan;
    }

    public async Task<List<PricingPlan>> GetAllAsync()
    {
        var pricingPlan = await _context.PricingPlans.ToListAsync();
        return pricingPlan;
    }

    public async Task<PricingPlan> UpdateAsync(PricingPlan pricingPlan)
    {
         _context.PricingPlans.Update(pricingPlan);
        _ = await _context.SaveChangesAsync();
        return pricingPlan;
    }
}
