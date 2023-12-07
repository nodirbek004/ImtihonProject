using MediatR;
using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Car.Queries;

namespace Yandex.Application.UseCases.Car.Handlers;

public class GetByIdCarInformationCommandHendler : IRequestHandler<GetByIdCarInformationCommand, Yandex.Domain.Entities.Car>
{
    private readonly IAppDbContext _appDbContext;
    public GetByIdCarInformationCommandHendler(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Domain.Entities.Car> Handle(GetByIdCarInformationCommand request, CancellationToken cancellationToken)
    {
        var res=await _appDbContext.Cars.FirstOrDefaultAsync(x=> x.Id == request.Id);
        if (res == null)
        {
            throw new Exception("yoq bunday orin");
        }
        return res;
    }
}
