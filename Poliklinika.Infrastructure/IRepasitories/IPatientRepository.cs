using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.IRepasitories;

public interface IPatientRepository:IRepository<PatientEntity>
{
    Task<PatientEntity> GetByTelNumber(string telNumber);
    IQueryable<PatientEntity> SearchByName(string name);
}
