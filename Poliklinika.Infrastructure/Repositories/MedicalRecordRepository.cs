using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.Repositories;

public class MedicalRecordRepository:Repository<MedicalRecord>,IMedicalRecordRepository
{
    public MedicalRecordRepository(AppDbContext options) : base(options)
    {
    }
    public IQueryable<MedicalRecord> GetByPatientId(long id)
        => _appDbContext.MedicalRecords.Where(m => m.PatientId == id);
}
