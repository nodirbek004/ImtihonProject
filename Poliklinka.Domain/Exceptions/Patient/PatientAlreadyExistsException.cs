namespace Poliklinka.Domain.Exceptions.Patient;

public class PatientAlreadyExistsException : NotFoundException
{
    public PatientAlreadyExistsException()
    {
        TitleMessage = "Patient already exist";
    }
}
