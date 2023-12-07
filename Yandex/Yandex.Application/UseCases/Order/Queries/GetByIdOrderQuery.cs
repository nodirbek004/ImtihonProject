using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.Order.Queries;

public class GetByIdOrderQuery:AudiTable, IRequest<Domain.Entities.Order>
{
}
