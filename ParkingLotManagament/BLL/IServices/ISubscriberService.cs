using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices
{
    public interface ISubscriberService
    {
        Task<IEnumerable<SubscriberViewModel>> GetAll();
        Task<SubscriberViewModel> GetSubscriberById(int id);
        Task<SubscriberViewModel> CreateSubscriber(SubscriberViewModel subscriberViewModel);
        Task<bool> DeleteSubscriber(int id);
        Task<SubscriberViewModel> UpdateSubscriber(SubscriberViewModel subscriberViewModel);
    }
}
