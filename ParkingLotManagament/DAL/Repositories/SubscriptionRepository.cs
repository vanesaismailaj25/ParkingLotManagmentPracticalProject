using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        ParkingLotManagementDatabaseContext _context;

        public SubscriptionRepository(ParkingLotManagementDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            var result = _context.Subscriptions.Add(subscription);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Subscription> DeleteSubscriptionAsync(int subscriberId)
        {
            var entity = await GetSubscriptionAsync(subscriberId);
            entity.IsDeleted= true;
            var result = _context.Subscriptions.Remove(entity);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> ExistsAsync(int subscriberId)
        {
            var result = await _context.Subscriptions.AnyAsync(s => s.SubscriberId == subscriberId && s.IsDeleted==false);
            return result;
        }

        public async Task<List<Subscription>> GetAllSubscriptionAsync()
        {
            var result = await _context.Subscriptions.ToListAsync();
            return result;
        }


        //should get the subscription by code or subscriber name
        public async Task<Subscription> GetSubscriptionAsync(int subscriberId)
        {
            var result = await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriberId && s.IsDeleted==false);
            return result;
        }

        public async Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {
            var result = _context.Subscriptions.Update(subscription);
            _ = await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
