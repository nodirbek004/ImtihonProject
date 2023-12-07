using Yandex.Domain.Commons;

namespace Yandex.Domain.Entities;

public class User:AudiTable
{
    public string  FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int CardId { get; set; }
}
