using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.Services
{

    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository subscriberRepository;

        public SubscriberService(ISubscriberRepository _subscriberRepository)
        {
            subscriberRepository = _subscriberRepository;
        }

        public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
        {
            return await subscriberRepository.CreateSubscriber(subscriber);
        }

       
        public async Task<IEnumerable<Subscriber>> GetAll()
        {
            return await subscriberRepository.GetAll();
        }

        public async Task<Subscriber> GetSubscriberById(int id)
        {
            return await subscriberRepository.GetSubscriberById(id);
        }

        public async Task<bool> DeleteSubscriber(int id)
        {
           return await subscriberRepository.DeleteSubscriber(id);
        }

        public async Task<Subscriber> UpdateSubscriber(Subscriber subscriber)
        {
            return await subscriberRepository.UpdateSubscriber(subscriber);
        }
    }
}