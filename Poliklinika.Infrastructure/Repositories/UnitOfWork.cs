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
        DoctorRepository = new DoctorRepository(dbContext);
        MedicalRecordRepository = new MedicalRecordRepository(dbContext);
        AppointmentRepository = new AppointmentRepository(dbContext);

    }


    public IPatientRepository PatientRepository { get;  }

    public IDoctorRepository DoctorRepository { get; }

    public IAppointmentRepository AppointmentRepository { get; }
    public IMedicalRecordRepository MedicalRecordRepository { get; }

    public async Task<int> SaveAsync()
         => await this.appDbContext.SaveChangesAsync();
}
