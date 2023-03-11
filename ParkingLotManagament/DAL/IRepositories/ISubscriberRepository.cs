using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface ISubscriberRepository
    {
        Task<Subscriber> CreateSubscriber(Subscriber subscriber);
        Task<Subscriber> UpdateSubscriber(Subscriber subscriber);
        Task<bool> DeleteSubscriber(int id);
        Task<IEnumerable<Subscriber>> GetAll();
        Task<Subscriber>  GetSubscriberById(int id);
        Task<bool> Exist (int id);
        
    }
  
   
}
