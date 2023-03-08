using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAll();
        Task<Subscriber>  GetSubscriberById(int id);
        Task<Subscriber> CreateSubscriber(Subscriber subscriber);
       Task<bool> DeleteSubscriber(int id);
        Task<Subscriber> UpdateSubscriber(Subscriber subscriber);
        
    }
  
   
}
