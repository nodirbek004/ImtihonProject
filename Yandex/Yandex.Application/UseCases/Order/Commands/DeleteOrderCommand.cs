using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.Order.Commands;

public class DeleteOrderCommand:AudiTable,IRequest<bool>
{
}
