using System.Net;

namespace Poliklinka.Domain.Exceptions.Doctor;

public class DoctorAlreadyExistsException:NotFoundException
{
    public DoctorAlreadyExistsException()
    {
        TitleMessage = "Doctor already exist";
    }
}
