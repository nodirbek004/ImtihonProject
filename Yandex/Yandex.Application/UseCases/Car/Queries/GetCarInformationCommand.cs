using MediatR;

namespace Yandex.Application.UseCases.Car.Queries;

public class GetCarInformationCommand:IRequest<List<Yandex.Domain.Entities.Car>>
{

}
