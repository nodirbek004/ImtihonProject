using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restarant.Application.DTOs.Cook;
using Restarant.Application.Interfaces;
using System.Diagnostics.Contracts;

namespace Restarant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CookController : ControllerBase
{
    private readonly ICookService cookService;
    public CookController(ICookService cookService)
    {
        this.cookService = cookService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]CookCreationDto dto)
    {
        var result=await cookService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]CookUpdateDto dto)
    {
        var result=await cookService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await cookService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await cookService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await cookService.GetByIdAsync(id);
        return Ok(result);
    }
    //[HttpGet]
    //public async ValueTask<IActionResult> SearchByName(string name)
    //{
    //    var result = await cookService.GetByNameAsync(name);
    //    return Ok(result);
    //}
}
