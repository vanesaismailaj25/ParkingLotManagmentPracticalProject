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

        public async Task<bool> DeleteSubscriptionAsync(int subscriberId)
        {
            var entity = await GetSubscriptionAsync(subscriberId);
            entity.IsDeleted = true;
            var saved = _context.Subscriptions.Update(entity);
            _ = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int subscriberId)
        {
            var result = await _context.Subscriptions.Where(x => x.IsDeleted == false).AnyAsync(s => s.SubscriberId == subscriberId);
            return true;
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            var result = await _context.Subscriptions.Include(x => x.Subscriber).Where(x => x.IsDeleted == false).ToListAsync();
            return result;
        }


        //should get the subscription by code or subscriber name
        public async Task<Subscription> GetSubscriptionAsync(int subscriberId)
        {
            var result = await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriberId && s.IsDeleted == false);
            return result;
        }

        public async Task<Subscription> GetSubscriptionByPlate(string plateNumber)
        {
            // Remove all spaces from the plate number
            string normalizedPlateNumber = plateNumber.Replace(" ", "").ToLower();


            var result = await _context.Subscriptions
                                    .Include(s => s.Subscriber)
                                    .Join(_context.Subscribers,
                                          sub => sub.SubscriberId,
                                          subscr => subscr.Id,
                                          (sub, subscr) => new { Subscription = sub, Subscriber = subscr })
                                          .Where(ss => ss.Subscriber.PlateNumber.Replace(" ", "").ToLower() == normalizedPlateNumber)
                                          .Select(ss => ss.Subscription)
                                          .FirstOrDefaultAsync();
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
