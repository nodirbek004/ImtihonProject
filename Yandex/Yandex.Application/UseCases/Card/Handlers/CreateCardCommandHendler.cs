using MediatR;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Card.Commands;

namespace Yandex.Application.UseCases.Card.Handlers;

public class CreateCardCommandHendler : IRequestHandler<CreateCardCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public CreateCardCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var Cards = new Domain.Entities.Card()
        {
            Name = request.Name,
            Number = request.Number,
            Salary = request.Salary,
            Data = request.Data
        };
        await appDbContext.Cards.AddAsync(Cards);
        int res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
