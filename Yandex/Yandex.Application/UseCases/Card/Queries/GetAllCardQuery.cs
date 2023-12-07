using MediatR;

namespace Yandex.Application.UseCases.Card.Queries;

public class GetAllCardQuery:IRequest<List<Domain.Entities.Card>>
{
}
