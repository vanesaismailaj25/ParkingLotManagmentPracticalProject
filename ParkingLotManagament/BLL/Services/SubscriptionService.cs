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
                SubscriberId = subscriptionViewModel.SubscriberId,
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

        public async Task<bool> DeleteSubscription(int id)
        {
            if (await _repository.ExistsAsync(id))
            {
                var entity = await _repository.DeleteSubscriptionAsync(id);
                return true;

            }
            else { throw new InvalidDataException(); }
        }

        public async Task<SubscriptionViewModel> GetSubscriptionById(int Id)
        {
            var result = await _repository.GetSubscriptionAsync(Id);
            var mappedSubscription = _mapper.Map<SubscriptionViewModel>(result);
            return mappedSubscription;
        }

        public async Task<SubscriptionViewModel> UpdateSubscription(SubscriptionViewModel subscriptionViewModel)
        {
            var code = CodeGenerator.SubscribtionGenerateCode(
                                                                subscriptionViewModel.StartDate,
                                                                subscriptionViewModel.Id,
                                                                subscriptionViewModel.SubscriberId,
                                                                subscriptionViewModel.Price,
                                                                subscriptionViewModel.EndDate);

            var mappedSubscription = _mapper.Map<Subscription>(subscriptionViewModel);
            mappedSubscription.Code = code;

            var updatedSubscription = await _repository.UpdateSubscriptionAsync(mappedSubscription);

            var updatedSubscriptionView = _mapper.Map<SubscriptionViewModel>(updatedSubscription);

            return updatedSubscriptionView;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var result = await _repository.GetAll();
            var mappedSubscription = _mapper.Map<IEnumerable<SubscriptionViewModel>>(result);
            return mappedSubscription;
        }
    }

}
