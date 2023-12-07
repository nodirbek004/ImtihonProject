using MediatR;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.User.Commands;

public class UpdateUserCommand:AudiTable,IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int CatdId { get; set; }
}
