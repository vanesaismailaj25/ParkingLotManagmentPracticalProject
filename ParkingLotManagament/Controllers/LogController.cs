using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;
using System.ComponentModel;

namespace ParkingLotManagament.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService _logService;
        private readonly ISubscriptionService _subscriptionService;

        public LogController(ILogService logService, ISubscriptionService subscriptionService)
        {
            _logService = logService;
            _subscriptionService = subscriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _logService.GetAll();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var listOfSubscribtions =  await _subscriptionService.GetAll();
            ViewBag.ListSubscriptions = new SelectList(listOfSubscribtions, "Id", "Plate");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LogViewModel logViewModel)
        {
            var result = await _logService.CreateLog(logViewModel);
            return View(result);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var result = await _logService.GetLog(Id);
            return View(result);
        }
    }
}
