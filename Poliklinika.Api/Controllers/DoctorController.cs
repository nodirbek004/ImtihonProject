using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.Doctors;
using Poliklinika.Application.Interfaces;

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
}
