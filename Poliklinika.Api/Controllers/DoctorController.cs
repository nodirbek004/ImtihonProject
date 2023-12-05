using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.Doctors;
using Poliklinika.Application.Interfaces;
using System.Globalization;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]DoctorCreationDto dto)
    {
        var result=await doctorService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(DoctorUpdateDto dto)
    {
        var result=await doctorService.UpdateAsync(dto);
        return Ok(result);

    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result =await doctorService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
     public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await doctorService.GetAllAsync();
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await doctorService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByTelNumber(string phone)
    {
        var result = doctorService.GetByTelNumber(phone);
        return Ok(result);
    }
}
