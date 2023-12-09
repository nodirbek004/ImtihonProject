using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yandex.Application.UseCases.Car.Commands;
using Yandex.Application.UseCases.Car.Queries;

namespace Yandex.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]


public class CarCantroller : ControllerBase
{
    private readonly IMediator mediator;

    public CarCantroller(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]CreateCarInformationCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateCarInformationCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int id) 
    {
        var result=await mediator.Send(new DeleteCarInformationCommand { Id = id });
        return Ok(result);
    }
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetCarInformationCommand());
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
    {
        var result = await mediator.Send(new GetByIdCarInformationCommand { Id = id });
        return Ok(result);
    }
}
