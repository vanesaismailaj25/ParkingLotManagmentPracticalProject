using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubscriptionAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> GetSubscriptionAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
