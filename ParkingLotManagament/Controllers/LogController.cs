using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using System.ComponentModel;

namespace ParkingLotManagament.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService logService;

        public LogController(ILogService _logService)
        {
            logService = _logService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await logService.GetAllLog();
            return View(result);
        }
        public async Task<IActionResult> Create(Log log)
        {
            var result =await logService.CreateLog(log);
            return View(result);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var result = await logService.GetLog(Id);
            return View(result);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await logService.DeleteLog(Id);
            return View(result);
        }
    }
}
