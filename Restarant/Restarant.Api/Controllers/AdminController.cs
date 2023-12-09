using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restarant.Application.DTOs.Admin;
using Restarant.Application.Interfaces;

namespace Restarant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "User")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {

        _adminService = adminService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result = await _adminService.GetAllAsync();

        return Ok(result);
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]AdminCreationDto dto)
    {
        var result=await _adminService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]AdminUpdateDto dto)
    {
        var result=await _adminService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await _adminService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await _adminService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByTelNumber(string number)
    {
        var result=await _adminService.GetByPhoneNumberAsync(number);
        return Ok(result);
    }
}
