using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Car.Queries;

namespace Yandex.Application.UseCases.Car.Handlers;

public class GetCarInformationCommandHendler : IRequestHandler<GetCarInformationCommand, List<Domain.Entities.Car>>
{
    private readonly IAppDbContext appDbContext;
    public GetCarInformationCommandHendler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task<List<Domain.Entities.Car>> Handle(GetCarInformationCommand request, CancellationToken cancellationToken)
    {
        var res= await appDbContext.Cars.ToListAsync(cancellationToken);
        return res;
    }
}
