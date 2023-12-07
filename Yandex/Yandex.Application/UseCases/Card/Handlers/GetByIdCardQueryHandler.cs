using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Card.Queries;

namespace Yandex.Application.UseCases.Card.Handlers;

public class GetByIdCardQueryHandler : IRequestHandler<GetByIdCardQuery, Domain.Entities.Card>
{
    private readonly IAppDbContext appDbContext;

    public GetByIdCardQueryHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<Domain.Entities.Card> Handle(GetByIdCardQuery request, CancellationToken cancellationToken)
    {
        var res = await appDbContext.Cards.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null)
        {
            throw new Exception("yoq bunday orin");
        }
        return res;
    }
}
