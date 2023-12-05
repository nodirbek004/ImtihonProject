using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.Patients;
using Poliklinika.Application.Interfaces;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService patientService;

    public PatientController(IPatientService patientService)
    { 
        this.patientService = patientService;   
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]PatientCreationDto dto)
    {
        var result= await patientService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        var result=await patientService.GetAllAsync();
        return Ok(result);
    }

    
}
