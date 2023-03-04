using Microsoft.AspNetCore.Mvc;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Controllers;

public class PricingPlanController : Controller
{
    private readonly IPricingPlanService _service;

    public PricingPlanController(IPricingPlanService service)
    {
        this._service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();
        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> Edit( PricingPlan pricingPlan)
    {
        await _service.UpdateAsync(pricingPlan);
        return RedirectToAction("Details",new {id=pricingPlan.Id});
    }
    [HttpGet]
    public async Task<IActionResult> Edit( int id)
    {
        var result = await _service.GetPricing(id);
        return View(result);
    }
    public  async Task<IActionResult> Details(int id) 
    {
        var result = await _service.GetPricing(id);
        return View(result);
    }

    
}
