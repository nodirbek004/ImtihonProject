namespace Restarant.Domain.Exceptions.Waiter;

public class WaiterNotFoundException:NotFoundException
{
    public WaiterNotFoundException()
    {
        TitleMessage = "waiter not found";
    }
}
