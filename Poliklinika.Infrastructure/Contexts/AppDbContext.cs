using Microsoft.EntityFrameworkCore;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.Migrate();
    }
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<PatientEntity> Patients { get; set; }
}
