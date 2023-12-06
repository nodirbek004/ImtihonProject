namespace Restarant.Domain.Exceptions.Admin;

public class AdminAllreadyExsistException:NotFoundException
{
    public AdminAllreadyExsistException()
    {
        TitleMessage = "admin allready exist";
    }
}
