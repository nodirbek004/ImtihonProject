using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Card.Commands;

namespace Yandex.Application.UseCases.Card.Handlers;

public class UpdateCardCommandHendler : IRequestHandler<UpdateCardCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public UpdateCardCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Cards.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (existCar is null)
        {
            throw new Exception("car not found");
        }
        appDbContext.Cards.Update(existCar);
        var res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
