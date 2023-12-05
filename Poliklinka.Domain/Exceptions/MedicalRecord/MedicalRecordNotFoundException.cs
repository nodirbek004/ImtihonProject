namespace Poliklinka.Domain.Exceptions.MedicalRecord;

public class MedicalRecordNotFoundException:NotFoundException
{
    public MedicalRecordNotFoundException()
    {
        TitleMessage = "this medicalrecord not found";
    }
}
