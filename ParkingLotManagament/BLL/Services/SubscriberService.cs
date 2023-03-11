using AutoMapper;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services
{

    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _repository;
        private readonly IMapper _mapper;

        public SubscriberService(ISubscriberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SubscriberViewModel> CreateSubscriber(SubscriberViewModel subscriberViewModel)
        {
            var subscriber = new Subscriber
            {
                Id = subscriberViewModel.Id,
                FirstName = subscriberViewModel.FirstName,
                LastName = subscriberViewModel.LastName,
                IdCardNumber = subscriberViewModel.IdCardNumber,
                Email = subscriberViewModel.Email,
                PhoneNumber = subscriberViewModel.PhoneNumber,
                Birthday = subscriberViewModel.Birthday,
                PlateNumber = subscriberViewModel.PlateNumber,
            };
            var result = await _repository.CreateSubscriber(subscriber);
            return new SubscriberViewModel
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                IdCardNumber = result.IdCardNumber,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Birthday = result.Birthday,
                PlateNumber = result.PlateNumber,

            };
        }

        public async Task<bool> DeleteSubscriber(int id)
        {
            if (await _repository.Exist(id))
            {
                await _repository.DeleteSubscriber(id);
                return true;
            }
            else 
            { 
                throw new InvalidDataException(); 
            }
        }

        public async Task<IEnumerable<SubscriberViewModel>> GetAll()
        {
            var result = await _repository.GetAll();
            var mappedSubscriber = _mapper.Map<IEnumerable<SubscriberViewModel>>(result);
            return mappedSubscriber;

        }

        public async Task<SubscriberViewModel> GetSubscriberById(int id)
        {
            var result = await _repository.GetSubscriberById(id);
            var mappedSubscriber = _mapper.Map<SubscriberViewModel>(result);
            return mappedSubscriber;

        }

        public async Task<SubscriberViewModel> UpdateSubscriber(SubscriberViewModel subscriberViewModel)
        {
            var mappedSubscriber = _mapper.Map<Subscriber>(subscriberViewModel);
            var updatedSubscriber = await _repository.UpdateSubscriber(mappedSubscriber);
            var updatedSubscriberView = _mapper.Map<SubscriberViewModel>(updatedSubscriber);
            return updatedSubscriberView;
        }
    }
}