using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yandex.Application.UseCases.Card.Queries;
using Yandex.Application.UseCases.User.Commands;

namespace Yandex.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CreateUserCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateUserCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int id)
    {
        var result=await mediator.Send(new DeleteUserCommand { Id = id });
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetAllCardQuery());
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
    {
        var result=await mediator.Send(new GetByIdCardQuery { Id = id });
        return Ok(result);
    }
}
