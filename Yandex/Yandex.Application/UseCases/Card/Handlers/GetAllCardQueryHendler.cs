using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Card.Queries;

namespace Yandex.Application.UseCases.Card.Handlers;

public class GetAllCardQueryHendler : IRequestHandler<GetAllCardQuery, List<Domain.Entities.Card>>
{
    private readonly IAppDbContext appDbContext;

    public GetAllCardQueryHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<List<Domain.Entities.Card>> Handle(GetAllCardQuery request, CancellationToken cancellationToken)
    {
        var res = await appDbContext.Cards.ToListAsync(cancellationToken);
        return res;
    }
}
