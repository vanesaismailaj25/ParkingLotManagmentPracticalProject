using AutoMapper;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        private readonly CodeGenerator _codeGenerator;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _codeGenerator = new CodeGenerator();
            _mapper = mapper;
        }

        public async Task<SubscriptionViewModel> CreateSubscription(SubscriptionViewModel subscriptionViewModel)
        {
            if (subscriptionViewModel == null)
            {
                throw new ArgumentNullException(nameof(subscriptionViewModel));
            }

            if (subscriptionViewModel.StartDate >= subscriptionViewModel.EndDate)
            {
                throw new ArgumentException("End date must be greater than start date.", nameof(subscriptionViewModel.EndDate));
            }

            var code = CodeGenerator.SubscribtionGenerateCode(
                subscriptionViewModel.StartDate,
                subscriptionViewModel.Id,
                subscriptionViewModel.SubscriberId,
                subscriptionViewModel.Price,
                subscriptionViewModel.EndDate);

            var newSubscription = new Subscription
            {
                Id = subscriptionViewModel.Id,
                Price = subscriptionViewModel.Price,
                DiscountValue = subscriptionViewModel.DiscountValue,
                StartDate = subscriptionViewModel.StartDate,
                EndDate = subscriptionViewModel.EndDate,
                Code = code
            };

            var result = await _repository.CreateSubscriptionAsync(newSubscription);
            return new SubscriptionViewModel
            {
                Id = result.Id,
                Price = result.Price,
                DiscountValue = result.DiscountValue,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
                SubscriberId = result.SubscriberId
            };
        }

        public async Task<Subscription> DeleteSubscription(Subscription subscription)
        {
            return await _repository.DeleteSubscriptionAsync(subscription.Id);
        }
        public async Task<bool> DeleteSubscription(int id)
        {
            var result = await _repository.GetSubscriptionAsync(id);
            var mappedSubscription = _mapper.Map<Subscription>(result);
            await _repository.DeleteSubscriptionAsync(result.Id);
            return true;
        }

        public async Task<List<Subscription>> GetAllSubscription()
        {
            return await _repository.GetAllSubscriptionAsync();
        }

        public async Task<SubscriptionViewModel> GetSubscriptionById(int Id)
        {
            var result = await _repository.GetSubscriptionAsync(Id);
            var mappedSubscription = _mapper.Map<SubscriptionViewModel>(result);
            return mappedSubscription;
        }

        public async Task<SubscriptionViewModel> UpdateSubscription(SubscriptionViewModel subscriptionViewModel)
        {
            var mappedSubscription = _mapper.Map<Subscription>(subscriptionViewModel);

            var updatedSubscription = await _repository.UpdateSubscriptionAsync(mappedSubscription);

            var updatedSubscriptionView = _mapper.Map<SubscriptionViewModel>(updatedSubscription);

            return updatedSubscriptionView;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var result = await _repository.GetAllSubscriptionAsync();
            var mappedSubscription = _mapper.Map<IEnumerable<SubscriptionViewModel>>(result);
            return mappedSubscription;
        }
    }

}
