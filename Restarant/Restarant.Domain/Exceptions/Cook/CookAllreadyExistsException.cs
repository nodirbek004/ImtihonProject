namespace Restarant.Domain.Exceptions.Cook;

public class CookAllreadyExistsException : NotFoundException
{
    public CookAllreadyExistsException()
    {
        TitleMessage = "cook already exist!";
    }
}
