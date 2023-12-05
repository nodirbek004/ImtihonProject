using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.IRepasitories;

public interface IMedicalRecordRepository : IRepository<MedicalRecord>
{
    IQueryable<MedicalRecord> GetByPatientId(long id);
}
