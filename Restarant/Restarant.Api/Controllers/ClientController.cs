using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restarant.Application.DTOs.Client;
using Restarant.Application.Interfaces;
using System.Globalization;

namespace Restarant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class ClientController : ControllerBase
{
    private readonly IClientService clientService;
    public ClientController(IClientService clientService)
    {
        this.clientService = clientService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]ClientCreationDto dto)
    {
        var result=await clientService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]ClientUpdateDto dto)
    {
        var result=await clientService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result=await clientService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await clientService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id) 
    {
        var result=await clientService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByTelNumber(string number)
    {
        var result=await clientService.GetByPhoneNumberAsync(number);
        return Ok(result);
    }
}
