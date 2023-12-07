using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yandex.Application.UseCases.Card.Commands;
using Yandex.Application.UseCases.Card.Queries;

namespace Yandex.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CardController : ControllerBase
{
    private readonly IMediator mediator;

    public CardController(IMediator mediator)
    {
        this.mediator = mediator;
    } 
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm]CreateCardCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateCardCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int id)
    {
        var result=await mediator.Send(new DeleteCardCommand() { Id=id});
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result=await mediator.Send(new GetAllCardQuery());
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
    {
        var result= await mediator.Send(new GetByIdCardQuery() { Id=id});
        return Ok(result);
    }
}
