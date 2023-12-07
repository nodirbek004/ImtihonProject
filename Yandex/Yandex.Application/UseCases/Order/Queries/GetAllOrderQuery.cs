using MediatR;

namespace Yandex.Application.UseCases.Order.Queries;

public class GetAllOrderQuery:IRequest<List<Domain.Entities.Order>>
{
}
