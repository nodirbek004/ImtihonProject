namespace Restarant.Domain.Exceptions.Client;

public class ClientNotFoundException:NotFoundException
{
    public ClientNotFoundException()
    {
        TitleMessage = "client not found";
    }
}
