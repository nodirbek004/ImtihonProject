using MediatR;

namespace Yandex.Application.UseCases.User.Commands;

public class CreateUserCommand:IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int CardId { get; set; }
}
