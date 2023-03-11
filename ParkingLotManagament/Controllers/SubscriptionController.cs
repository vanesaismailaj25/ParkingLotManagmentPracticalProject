using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var subscription = await _service.GetAll();
            return View(subscription);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var subscriptionModel = await _service.GetSubscriptionById(id);
            return View(subscriptionModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionViewModel subscriptionViewModel)
        {
            var result = await _service.CreateSubscription(subscriptionViewModel);

            return RedirectToAction("Details", new { id = result.Id });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetSubscriptionById(id);
           return View(result);
        }

        [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteSub(int id)
        {
            await _service.DeleteSubscription(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetSubscriptionById(id);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(SubscriptionViewModel subscriptionViewModel)
        {
            var result = await _service.UpdateSubscription(subscriptionViewModel);
            return RedirectToAction("Details", new { id = subscriptionViewModel.Id });

        }
    }
}
