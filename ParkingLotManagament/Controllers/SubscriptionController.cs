using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.Repositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionController(ISubscriptionService _subscriptionService)
        {
            subscriptionService = _subscriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var subscription = await subscriptionService.GetAllSubscription();
            return View(subscription);
        }

        public async Task<IActionResult> Details(int subscriberId)
        {
            var subscriptionModel = await subscriptionService.GetSubscriptionBySubscriberId(subscriberId);
            return View(subscriptionModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public async Task<IActionResult> CreateSubscription(Subscription subscription)
        {
           
                var result = await subscriptionService.CreateSubscription(subscription);
                return View(result);
         }
        public async Task<IActionResult> Update(Subscription subscription)
        {
           var result = await subscriptionService.UpdateSubscription(subscription);
            return View(result);
        }

    }
}
