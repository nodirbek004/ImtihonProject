using MediatR;

namespace Yandex.Application.UseCases.User.Queries;

public class GetAllUserQuery:IRequest<List<Domain.Entities.User>>
{

}

