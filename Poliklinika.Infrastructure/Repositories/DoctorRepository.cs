using Microsoft.EntityFrameworkCore;
using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.Repositories;

public class DoctorRepository : Repository<DoctorEntity>, IDoctorRepository
{
    public DoctorRepository(AppDbContext appContext) : base(appContext)
    {
    }
    public async Task<DoctorEntity> GetByTelNumberAsync(string telNumber)
           => await _appDbContext.Doctors.FirstOrDefaultAsync(t => t.TelNumber.Equals(telNumber));

}
