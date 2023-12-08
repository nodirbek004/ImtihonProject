using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Poliklinika.Application.DTOs.Appointments;
using Poliklinika.Application.Services;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles ="User")]
public class AppointmentController : ControllerBase
{
    private readonly AppontmentService _appontmentService;
    private readonly IMemoryCache cache;
    public AppointmentController(AppontmentService appontmentService, IMemoryCache cache)
    {
        _appontmentService = appontmentService;
        this.cache = cache;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] AppoinmentCreationDto dto)
    {
        var result = await _appontmentService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] AppoinmentUpdateDto dto)
    {
        var result = await _appontmentService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await _appontmentService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var cash = cache.Get("GetAll");
        if (cash is null) 
        {
        var result = await _appontmentService.GetAllAsync();
            var results = cache.Set("GetAll", result);
        }
        return Ok(cache.Get("GetAll"));
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result = await _appontmentService.GetByIdAsync(id);
        return Ok(result);
    }
}
