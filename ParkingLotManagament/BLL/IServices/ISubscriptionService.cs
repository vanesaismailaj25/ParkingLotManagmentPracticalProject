using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices;

public interface ISubscriptionService
{
    Task<SubscriptionViewModel> CreateSubscription(SubscriptionViewModel subscriptionViewModel );
    Task<SubscriptionViewModel> UpdateSubscription(SubscriptionViewModel subscriptionViewModel);
    Task<SubscriptionViewModel> GetSubscriptionById(int subscriberId);
    public Task<bool> DeleteSubscription(int id);
    Task<IEnumerable<SubscriptionViewModel>> GetAll();
}
