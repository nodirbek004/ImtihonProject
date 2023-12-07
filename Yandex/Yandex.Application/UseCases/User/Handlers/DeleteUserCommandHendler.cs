using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.User.Commands;

namespace Yandex.Application.UseCases.User.Handlers;

public class DeleteUserCommandHendler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public DeleteUserCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (existCar == null)
        {
            return false;
        }

        appDbContext.Users.Remove(existCar);
        var res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
