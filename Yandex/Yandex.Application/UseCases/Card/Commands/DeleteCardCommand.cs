using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.Card.Commands;

public class DeleteCardCommand:AudiTable,IRequest<bool>
{

}
