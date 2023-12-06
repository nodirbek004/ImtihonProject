namespace Restarant.Domain.Exceptions.Client;

public class ClientAllreadyExsistException:NotFoundException
{
    public ClientAllreadyExsistException()
    {
        TitleMessage = "client allready exist!";
    }
}
