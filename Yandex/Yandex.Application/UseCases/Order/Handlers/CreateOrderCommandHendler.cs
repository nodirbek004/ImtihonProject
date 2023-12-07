using MediatR;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Order.Commands;

namespace Yandex.Application.UseCases.Order.Handlers;

public class CreateOrderCommandHendler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public CreateOrderCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orders = new Domain.Entities.Order()
        {
            UserId = request.UserId,
            AddressWhere=request.AddressWhere,
            AddressWhereTo=request.AddressWhereTo,
            CarId=request.CarId,
            Status=request.Status
        };
        await appDbContext.Orders.AddAsync(orders);
        int res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
