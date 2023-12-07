using MediatR;


namespace Yandex.Application.UseCases.Car.Queries;

public class GetByIdCarInformationCommand:IRequest<Yandex.Domain.Entities.Car>
{
    public int Id { get; set; }
}
