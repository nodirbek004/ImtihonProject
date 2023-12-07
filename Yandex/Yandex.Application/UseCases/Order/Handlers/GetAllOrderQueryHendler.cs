using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Order.Queries;

namespace Yandex.Application.UseCases.Order.Handlers;

public class GetAllOrderQueryHendler : IRequestHandler<GetAllOrderQuery, List<Domain.Entities.Order>>
{
    private readonly IAppDbContext appDbContext;

    public GetAllOrderQueryHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<List<Domain.Entities.Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {

        var res = await appDbContext.Orders.ToListAsync(cancellationToken);
        return res;
    }
}
