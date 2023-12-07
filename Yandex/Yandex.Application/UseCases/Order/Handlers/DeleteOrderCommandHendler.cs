using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Order.Commands;

namespace Yandex.Application.UseCases.Order.Handlers;

public class DeleteOrderCommandHendler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public DeleteOrderCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (existCar == null)
        {
            return false;
        }

        appDbContext.Orders.Remove(existCar);
        var res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
