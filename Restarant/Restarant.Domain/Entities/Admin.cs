using Restarant.Domain.Commons;

namespace Restarant.Domain.Entities;

public class Admin : AudiTable
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CookId { get; set; }
    public int WaiterId { get; set; }
}
