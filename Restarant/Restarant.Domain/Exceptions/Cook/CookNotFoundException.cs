namespace Restarant.Domain.Exceptions.Cook;

public class CookNotFoundException:NotFoundException
{
    public CookNotFoundException()
    {
        TitleMessage = "cook not found";
    }
}
