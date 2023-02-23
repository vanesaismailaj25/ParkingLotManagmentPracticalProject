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

    public IActionResult Index()
    {
        return View();
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
