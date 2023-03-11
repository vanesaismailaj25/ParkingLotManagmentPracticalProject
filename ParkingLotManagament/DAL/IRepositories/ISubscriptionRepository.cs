using ParkingLotManagament.Models;
namespace ParkingLotManagament.DAL.IRepositories;


    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription> UpdateSubscriptionAsync(Subscription subscription);
        Task<bool> DeleteSubscriptionAsync(int subscriberId);
        Task<Subscription> GetSubscriptionAsync(int subscriberId);
        Task<IEnumerable<Subscription>> GetAll();
        Task<bool> ExistsAsync(int subscriberId);

    }

