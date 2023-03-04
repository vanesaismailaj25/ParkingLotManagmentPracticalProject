using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;

namespace ParkingLotManagament.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionController(ISubscriptionService _subscriptionService)
        {
            subscriptionService = _subscriptionService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var subscriberId = subscriptionService.GetSubscriptionBySubscriberId();

        }
    }
}
