using MediatR;

namespace Yandex.Application.UseCases.Card.Commands;

public class CreateCardCommand:IRequest<bool>
{
    public string Name { get; set; }
    public string Number { get; set; }
    public string Data { get; set; }
    public float Salary { get; set; }
}
