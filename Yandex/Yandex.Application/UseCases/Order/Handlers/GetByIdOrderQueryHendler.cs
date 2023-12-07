using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Order.Queries;

namespace Yandex.Application.UseCases.Order.Handlers;

public class GetByIdOrderQueryHendler : IRequestHandler<GetByIdOrderQuery, Domain.Entities.Order>
{
    private readonly IAppDbContext appDbContext;

    public GetByIdOrderQueryHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<Domain.Entities.Order> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
    {
        var res = await appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null)
        {
            throw new Exception("yoq bunday orin");
        }
        return res;
    }
}
