namespace Restarant.Domain.Exceptions.Waiter;

public class WaiterAllreadyExistsException:NotFoundException
{
    public WaiterAllreadyExistsException()
    {
        TitleMessage = "waiter allready exist!";
    }
}
