namespace Poliklinka.Domain.Exceptions.Doctor;

public class DoctorNotFoundException:NotFoundException
{
    public DoctorNotFoundException()
    {
        TitleMessage = "this Doctor not found";
    }
}
