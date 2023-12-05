namespace Poliklinka.Domain.Exceptions.Patient;

public class PatientNotFoundException:NotFoundException
{
    public PatientNotFoundException()
    {
        TitleMessage = "this patient not found ";
    }
}
