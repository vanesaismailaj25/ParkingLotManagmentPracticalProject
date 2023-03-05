using ParkingLotManagament.Models;
namespace ParkingLotManagament.DAL.IRepositories;


    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription> UpdateSubscriptionAsync(Subscription subscription);
        Task<Subscription> DeleteSubscriptionAsync(int subscriberId);
        Task<Subscription> GetSubscriptionAsync(int subscriberId);
        Task<List<Subscription>> GetAllSubscriptionAsync();
        Task<bool> ExistsAsync(int subscriberId);

    }

