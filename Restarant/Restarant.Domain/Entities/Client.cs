using Restarant.Domain.Commons;

namespace Restarant.Domain.Entities;

public class Client:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }


}
