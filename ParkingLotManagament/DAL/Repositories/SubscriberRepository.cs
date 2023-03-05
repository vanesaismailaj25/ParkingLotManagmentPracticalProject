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

        public async Task<IEnumerable<Subscriber>> GetAll()
        {
            var subscriber = await _context.Subscribers.Where(x => x.IsDeleted == false).ToListAsync();
            return subscriber;
        }

        public async Task<Subscriber> Get(int? id)
        {
            return await _context.Subscribers.FindAsync(id);
        }

        public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();
            return subscriber;
        }

        
        public async Task<Subscriber> UpdateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();
            return subscriber;
        }

        public async Task<Subscriber> GetSubscriberById(int id)
        {
            return await _context.Subscribers.FindAsync(id);
        }

        public async Task<bool> SoftDeleteSubscriberAsync(int id)
        {
            Subscriber subscriber = await _context.Subscribers.FindAsync(id);
            subscriber.IsDeleted = true;
            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}