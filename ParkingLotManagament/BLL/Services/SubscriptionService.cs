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
        private readonly IPricingPlanService _pricingPlanService;
        private readonly Calculations _calculations;

        public SubscriptionService(ISubscriptionRepository repository, IMapper mapper, IPricingPlanService pricingPlanService)
        {
            _repository = repository;
            _codeGenerator = new CodeGenerator();
            _mapper = mapper;
            _pricingPlanService = pricingPlanService;
            _calculations = new Calculations();
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

            var weekDay = await _pricingPlanService.GetWeekEnd(false);
            var weekEnd = await _pricingPlanService.GetWeekEnd(true);


            decimal cost = Calculations.CalculateMonthlySubscription(subscriptionViewModel.StartDate, subscriptionViewModel.EndDate, weekDay.DailyPricing, weekEnd.DailyPricing);
            decimal amount = Calculations.CalculateAmount(cost, (decimal)subscriptionViewModel.DiscountValue);

            var code = CodeGenerator.SubscribtionGenerateCode(
                subscriptionViewModel.StartDate,
                subscriptionViewModel.Id,
                subscriptionViewModel.SubscriberId,
                subscriptionViewModel.EndDate);
            TimeSpan duration = subscriptionViewModel.EndDate - subscriptionViewModel.StartDate;

            if (duration.TotalHours > 12)
            {
                //int days = (int)Math.Ceiling(duration.TotalDays);
                //if (subscriptionViewModel.EndDate==DayOfWeek.Saturday || subscriptionViewModel.EndDate==DayOfWeek.) { }
                //var dailyprice = _pricingPlanService.GetPricingPlan(x=>x.Id==
            }



            var newSubscription = new Subscription
            {
                Id = subscriptionViewModel.Id,
                Price = cost,
                DiscountValue = subscriptionViewModel.DiscountValue,
                AmountToBePaid = amount,
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
                AmountToBePaid = amount,
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
