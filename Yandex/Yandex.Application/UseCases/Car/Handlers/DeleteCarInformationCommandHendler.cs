using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Car.Commands;

namespace Yandex.Application.UseCases.Car.Handlers;

public class DeleteCarInformationCommandHendler : IRequestHandler<DeleteCarInformationCommand, bool>
{
    private readonly IAppDbContext appDbContext;
    public DeleteCarInformationCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<bool> Handle(DeleteCarInformationCommand request, CancellationToken cancellationToken)
    {
        var existCar = await appDbContext.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (existCar == null) 
        {
            return false;
        }

        appDbContext.Cars.Remove(existCar);
       var res= await appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
