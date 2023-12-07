using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.User.Commands;

namespace Yandex.Application.UseCases.User.Handlers;

public class UpdateUserCommandHendler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public UpdateUserCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (existCar is null)
        {
            throw new Exception("User not found");
        }
        appDbContext.Users.Update(existCar);
        var res = await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
