namespace Poliklinika.Infrastructure.IRepasitories;

public interface IUnitOfWork
{
    IPatientRepository PatientRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IMedicalRecordRepository MedicalRecordRepository { get; }
    Task<int> SaveAsync();
}
