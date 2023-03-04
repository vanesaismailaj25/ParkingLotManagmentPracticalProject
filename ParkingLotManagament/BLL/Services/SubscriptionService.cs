using Microsoft.CodeAnalysis.CSharp.Syntax;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository _subscriptionRepository)
        {
           subscriptionRepository = _subscriptionRepository;
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription, Guid code)
        {
           if(await subscriptionRepository.ExistsAsync(code))
            {
                throw new Exception("There already is a subscription with the given code!");

            }
            var Subscription = new Subscription
            {
                Price = subscription.Price,
                DiscountValue = subscription.DiscountValue,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
            };
            var result =await subscriptionRepository.CreateSubscriptionAsync(Subscription);  
            return result;
        }

        public async Task<Subscription> DeleteSubscription(Subscription subscription)
        {
            throw new NotImplementedException();    
        }

        public async Task<List<Subscription>> GetAllSubscription()
        {
            return await subscriptionRepository.GetAllSubscriptionAsync();
        }

        public async Task<Subscription> GetSubscriptionBySubscriberId(int subscriberId)
        {
            return await subscriptionRepository.GetSubscriptionAsync(subscriberId);
        }

        public Task<Subscription> UpdateSubscription(Subscription subscription)
        {
           return subscriptionRepository.UpdateSubscriptionAsync(subscription);
        }
    }
}
