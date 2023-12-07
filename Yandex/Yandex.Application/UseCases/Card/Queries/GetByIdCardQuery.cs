using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.Card.Queries;

public class GetByIdCardQuery:AudiTable,IRequest<Domain.Entities.Card>
{
}
