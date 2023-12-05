using Microsoft.AspNetCore.Mvc;
using Poliklinika.Application.DTOs.MedicalRecords;
using Poliklinika.Application.Services;

namespace Poliklinika.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MedicalRecordController : ControllerBase
{
    private readonly MedicalRecordService _mediicalRecordService;

    public MedicalRecordController(MedicalRecordService medicalRecordService)
    {
        _mediicalRecordService = medicalRecordService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]MedicalRecordCreationDto dto)
    {
        var result=await _mediicalRecordService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]MedicalRecordUpdateDto dto)
    { 
        var result=await _mediicalRecordService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await _mediicalRecordService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await _mediicalRecordService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await _mediicalRecordService.GetByIdAsync(id);
        return Ok(result);
    }

}
