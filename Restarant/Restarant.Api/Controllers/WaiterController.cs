using Microsoft.AspNetCore.Mvc;
using Restarant.Application.DTOs.Waiter;
using Restarant.Application.Interfaces;

namespace Restarant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class WaiterController : ControllerBase
{
    private readonly IWaiterService waiterService;
    public WaiterController(IWaiterService waiterService)
    {
        this.waiterService = waiterService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]WaiterCreationDto dto)
    {
        var result=await waiterService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(WaiterUpdateDto dto)
    {
        var result=await waiterService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await waiterService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await waiterService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await waiterService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByTelNumber(string number)
    {
        var result=await waiterService.GetByPhoneNumberAsync(number);
        return Ok(result);
    }
}
