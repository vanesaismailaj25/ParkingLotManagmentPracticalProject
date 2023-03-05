using ParkingLotManagament.Models;
namespace ParkingLotManagament.BLL.IServices;

public interface ISubscriptionService
{
    Task<Subscription> CreateSubscription(Subscription subscription );
    Task<Subscription> UpdateSubscription(Subscription subscription);
    Task<Subscription> DeleteSubscription(Subscription subscription);
    Task<Subscription> GetSubscriptionBySubscriberId(int subscriberId);
    Task<List<Subscription>> GetAllSubscription();
}
