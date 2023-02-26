using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers;

public class PricingPlanController : Controller
{
    private readonly IPricingPlanService service;

    public PricingPlanController(IPricingPlanService _service)
    {
        service = _service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await service.GetAllAsync();
        return View(result);
    }
    public async Task<IActionResult> Update(int id, PricingPlan pricingPlan)
    {
        var updatePlan = await service.UpdateAsync(id, pricingPlan);
        return View(updatePlan);
    }
    public  async Task<IActionResult> Details() 
    {
        var result = await service.GetAllAsync();
        return View(result);
    }

    
}
