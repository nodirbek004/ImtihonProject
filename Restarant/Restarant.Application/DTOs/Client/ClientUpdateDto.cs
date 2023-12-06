using Restarant.Domain.Commons;

namespace Restarant.Application.DTOs.Client;

public class ClientUpdateDto:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
