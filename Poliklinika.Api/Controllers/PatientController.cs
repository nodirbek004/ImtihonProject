using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.Patients;
using Poliklinika.Application.Interfaces;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
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
    [HttpDelete]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var  result =await patientService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id) 
    {
        var result = await patientService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async ValueTask<IActionResult> SearchByName(string name) 
    {
        var result= patientService.GetByNameAsync(name);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> Update([FromForm]PatientUpdateDto dto)
    {
        var result= await patientService.UpdateAsync(dto);
        return Ok(result);
    }
    
}
