using Yandex.Domain.Commons;

namespace Yandex.Domain.Entities;

public class Card:AudiTable
{
    public string Name { get; set; }
    public string Number { get; set; }
    public string Data { get; set; }
    public float Salary { get; set; }

}
