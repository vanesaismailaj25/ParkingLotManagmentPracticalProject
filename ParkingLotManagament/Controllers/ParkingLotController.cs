
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers
{
    public class ParkingLotController : Controller
    {
        private readonly IParkingLotService _service;
        private readonly ISubscriptionService _subscriptionService;

        public ParkingLotController(IParkingLotService parkingService, ISubscriptionService subscriptionService)
        {
            _service = parkingService;
            _subscriptionService = subscriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _service.CountAll();

            return View(viewModel);
        }

        public async Task<IActionResult> Details()
        {
            var result = await _service.GetAll();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParkingDetailsViewModel parkingLot)
        {
           await _service.Edit(parkingLot);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var listOfSubscriptions = await _subscriptionService.GetAll();
            ViewBag.ListOfSubscriptions = new SelectList(listOfSubscriptions, "Id", "SubscriberId");
            var result = await _service.GetById(id);
            return View(result);
        }
    }


}

