using Microsoft.EntityFrameworkCore;
using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinika.Infrastructure.Repositories;
using Poliklinka.Domain.Entities;

namespace HospitalInformationSystem.Data.Repositories;

public class PatientRepository : Repository<PatientEntity>, IPatientRepository
{

    public PatientRepository(AppDbContext appdb) : base(appdb)
    {
    }

    public async Task<PatientEntity> GetByTelNumber(string telNumber)
        => await _appDbContext.Patients.FirstOrDefaultAsync(t => t.TelNumber.Equals(telNumber));

    public IQueryable<PatientEntity> SearchByName(string name)
        => _appDbContext.Patients.Where(p => p.FirstName.Contains(name)).AsQueryable();
}
