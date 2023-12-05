namespace Poliklinika.Infrastructure.IRepasitories;

public interface IUnitOfWork
{
    IPatientRepository PatientRepository { get; }
    Task<int> SaveAsync();
}
