using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        ParkingLotManagementDatabaseContext context;

        public SubscriptionRepository(ParkingLotManagementDatabaseContext _context)
        {
            context = _context;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
           
            //var entity = await ExistsAsync(code);
            //if (entity == null)
            //{
            //   var result = context.Subscriptions.Add(subscription);
            //    _ = await context.SaveChangesAsync();

            //    return result.Entity;
            //}
            //return;
            throw new NotImplementedException();
        }

        public async Task<Subscription> DeleteSubscriptionAsync(Subscription subscription, int subscriberId)
        {
            var entity = await GetSubscriptionAsync(subscriberId);
            var result = context.Subscriptions.Remove(entity);
            _ = await context.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<bool> ExistsAsync(int subscriberId)
        {
            var result = await context.Subscriptions.AnyAsync(s => s.SubscriberId == subscriberId);
            return result;
        }

        public async Task<List<Subscription>> GetAllSubscriptionAsync()
        {
            var result = await context.Subscriptions.ToListAsync();
            return result;
        }
        //should get the subscription by code or subscriber name
        public async Task<Subscription> GetSubscriptionAsync(int subscriberId)
        {
            var result = await context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriberId);
            return result;
        }

        public async Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {
            var result = context.Subscriptions.Update(subscription);
            _ = await context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
