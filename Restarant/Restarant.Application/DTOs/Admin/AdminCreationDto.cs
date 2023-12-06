namespace Restarant.Application.DTOs.Admin;

public class AdminCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CookId { get; set; }
    public int WaiterId { get; set; }
}
