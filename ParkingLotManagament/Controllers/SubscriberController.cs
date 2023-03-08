using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService _service;
        public SubscriberController(ISubscriberService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var subscriberViewModels = await _service.GetAll();
            return View(subscriberViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetSubscriberById(id);
            return View(result);
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubscriberViewModel subscriberViewModel)
        {
            var result = await _service.UpdateSubscriber(subscriberViewModel);
            return RedirectToAction("Details", new { id = subscriberViewModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetSubscriberById(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubscriberViewModel subscriberViewModel)
        {
            var result = await _service.CreateSubscriber(subscriberViewModel);
            return RedirectToAction("Details", new { id = result.Id });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(SubscriberViewModel subscriberViewModel)
        {
            var result = await _service.DeleteSubscriber(subscriberViewModel.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetSubscriberById(id);
            return View(result);
        }



    }


}