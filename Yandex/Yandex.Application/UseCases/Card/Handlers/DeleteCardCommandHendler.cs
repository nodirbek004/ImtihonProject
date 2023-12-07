using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Card.Commands;

namespace Yandex.Application.UseCases.Card.Handlers;

public class DeleteCardCommandHendler : IRequestHandler<DeleteCardCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public DeleteCardCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Cards.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (existCar == null)
        {
            return false;
        }

        appDbContext.Cards.Remove(existCar);
        var res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
