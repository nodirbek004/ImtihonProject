using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yandex.Application.UseCases.Order.Commands;
using Yandex.Application.UseCases.Order.Queries;

namespace Yandex.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly IMediator mediator;

    public OrderController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CreateOrderCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsnc(UpdateOrderCommand command)
    {
        var result=await mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int id)
    {
        var result = await mediator.Send(new DeleteOrderCommand { Id=id});
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetAllOrderQuery());
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
    {
        var result=await mediator.Send(new GetByIdOrderQuery{ Id=id});
        return Ok(result);
    }
}
