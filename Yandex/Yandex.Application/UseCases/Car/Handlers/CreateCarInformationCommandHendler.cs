using MediatR;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Car.Commands;

namespace Yandex.Application.UseCases.Car.Handlers;

public class CreateCarInformationCommandHendler : IRequestHandler<CreateCarInformationCommand, bool>
{
    private readonly IAppDbContext dbContext;
    public CreateCarInformationCommandHendler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> Handle(CreateCarInformationCommand request, CancellationToken cancellationToken)
    {
        var cars = new Domain.Entities.Car()
        {
            Model = request.Model,
            Color = request.Color,
            Number = request.Number
        };

        await dbContext.Cars.AddAsync(cars);
        int result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;


    }
}

