using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Car.Commands;

namespace Yandex.Application.UseCases.Car.Handlers;

public class UpdateCarInformationCommandHendler : IRequestHandler<UpdateCarInformationCommand, bool>
{
    private readonly IAppDbContext _appDbContext;
    public UpdateCarInformationCommandHendler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> Handle(UpdateCarInformationCommand request, CancellationToken cancellationToken)
    {
        var existCar = await _appDbContext.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (existCar is  null) 
        {
            throw new Exception("car not found");
        }
         _appDbContext.Cars.Update(existCar);
        var res = await _appDbContext.SaveChangesAsync(cancellationToken);
        return res > 0;
    }
}
