
 using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers
{
    public class ParkingLotController : Controller
    {
        private readonly IParkingLotService _service;

        public ParkingLotController(IParkingLotService parkingService)
        {
            _service = parkingService;
        }

        public IActionResult Index()
        {

            var totalSpots = _service.CountSpots();
            var reservedSpots = _service.CountReservedSpots();
            var freeSpots = totalSpots - reservedSpots;

            var viewModel = new ParkingLotViewModel
            {
                TotalSpots = totalSpots,
                ReservedSpots = reservedSpots,
                FreeSpots = freeSpots
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details()
        {
            var result = await _service.GetAll();
            return View(result);
        }
    }
}
