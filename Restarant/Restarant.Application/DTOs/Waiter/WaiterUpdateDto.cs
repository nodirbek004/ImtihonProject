using Restarant.Domain.Commons;

namespace Restarant.Application.DTOs.Waiter;

public class WaiterUpdateDto:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public float Salary { get; set; }
}
