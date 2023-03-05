using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using VisioForge.MediaFramework.ONVIF;

namespace ParkingLotManagament.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService subscriberService;
        public SubscriberController(ISubscriberService _subscribeService)
        {
            subscriberService = _subscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientList = await subscriberService.GetAll();
            return View(clientList);
        }

        public async Task<IActionResult> Details()
        {
            var result = await subscriberService.GetAll();
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                await subscriberService.UpdateSubscriber(subscriber);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subscriber);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subscriber = await subscriberService.GetSubscriberById(id);
            return View(subscriber);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> CreateSubscrber(Subscriber subscriber)
        {

            var result = await subscriberService.CreateSubscriber(subscriber);
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var subscriber = await subscriberService.GetSubscriberById(id);
            return View(subscriber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await subscriberService.SoftDeleteSubscriberAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
   
    
}