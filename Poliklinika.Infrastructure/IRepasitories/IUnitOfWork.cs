namespace Poliklinika.Infrastructure.IRepasitories;

public interface IUnitOfWork
{
    IPatientRepository PatientRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    Task<int> SaveAsync();
}
