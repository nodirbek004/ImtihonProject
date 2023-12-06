using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.Appointments;
using Poliklinika.Application.Services;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly AppontmentService _appontmentService;
    public AppointmentController(AppontmentService appontmentService)
    {
        _appontmentService = appontmentService;
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
        var result = await _appontmentService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result = await _appontmentService.GetByIdAsync(id);
        return Ok(result);
    }
}
