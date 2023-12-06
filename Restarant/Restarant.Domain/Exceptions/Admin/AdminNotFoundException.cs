namespace Restarant.Domain.Exceptions.Admin;

public class AdminNotFoundException:NotFoundException
{
    public AdminNotFoundException()
    {
        TitleMessage = "Admin Not Found";
    }
}
