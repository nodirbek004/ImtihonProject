using HospitalInformationSystem.Data.Repositories;
using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;

namespace Poliklinika.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        appDbContext = dbContext;
        PatientRepository = new PatientRepository(dbContext);
    }

    public IPatientRepository PatientRepository { get;  }
    public async Task<int> SaveAsync()
         => await this.appDbContext.SaveChangesAsync();
}
