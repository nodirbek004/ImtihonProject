namespace Poliklinka.Domain.Exceptions.MedicalRecord;

public class MedicalRecordAlreadyExistsException:NotFoundException
{
    public MedicalRecordAlreadyExistsException()
    {
        TitleMessage = "MedicalRecord already exist";
    }
}
