using ParkingLotManagament.Models;
namespace ParkingLotManagament.DAL.IRepositories;

public interface ISubscriptionRepository
{
    Task<Subscription> AddSubscriptionAsync(Subscription subscription);
    Task DeleteSubscriptionAsync(int Id);
    Task<Subscription> GetSubscriptionAsync(int Id);
    Task<List<Subscription>> GetAllSubscriptionsAsync();
    Task<Subscription> UpdateSubscriptionAsync(Subscription subscription);
}
