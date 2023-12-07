using Yandex.Domain.Commons;
using Yandex.Domain.Enums;

namespace Yandex.Domain.Entities;

public class Order:AudiTable
{
    public int UserId { get; set; }
    public string AddressWhere { get; set; }
    public string AddressWhereTo { get; set; }
    public int CarId { get; set; }
    public Status Status { get; set; }
}
