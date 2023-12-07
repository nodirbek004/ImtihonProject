using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.User.Queries;

public class GetByIdUserQuery:AudiTable,IRequest<Domain.Entities.User>
{

}
