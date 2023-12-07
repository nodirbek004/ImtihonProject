using MediatR;
using Yandex.Domain.Commons;
using Yandex.Domain.Enums;

namespace Yandex.Application.UseCases.Order.Commands;

public class UpdateOrderCommand:AudiTable,IRequest<bool>
{
    public int UserId { get; set; }
    public string AddressWhere { get; set; }
    public string AddressWhereTo { get; set; }
    public int CarId { get; set; }
    public Status Status { get; set; }
}
