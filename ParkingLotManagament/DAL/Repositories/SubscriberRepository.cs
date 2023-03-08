using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ParkingLotManagementDatabaseContext _context;

        public SubscriberRepository(ParkingLotManagementDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();
            return subscriber;
        }
        public async Task<bool> DeleteSubscriber(int id)
        {
            var entity = await GetSubscriberById(id);
            entity.IsDeleted = true;
            _ = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Exist(int id)
        {
            var result = await _context.Subscribers.AnyAsync(s => s.Id == id && s.IsDeleted == false);
            return result;
        }

        public async Task<IEnumerable<Subscriber>> GetAll()
        {
            var result = await _context.Subscribers.Where(x=>x.IsDeleted==false).ToListAsync();
            return result;
        }

        public async Task<Subscriber> GetSubscriberById(int id)
        {
            var subscriber = await _context.Subscribers
                                           .Where(x => x.IsDeleted == false)
                                           .FirstOrDefaultAsync(x => x.Id == id);
            return subscriber;
        }

        public async Task<Subscriber> UpdateSubscriber(Subscriber subscriber)
        {
            var result = _context.Subscribers.Update(subscriber);
            _ = await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}