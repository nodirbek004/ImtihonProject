using MediatR;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.User.Commands;

namespace Yandex.Application.UseCases.User.Handlers;

public class CreateUserCommandHendler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IAppDbContext appDbContext;

    public CreateUserCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var Users = new Domain.Entities.User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            CardId = request.CardId
        };
        await appDbContext.Users.AddAsync(Users);
        int res=await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
