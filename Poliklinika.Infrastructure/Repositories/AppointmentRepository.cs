using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.Repositories;

public class AppointmentRepository : Repository<AppointmentEntity>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext options) : base(options)
    {
    }
    public IQueryable<AppointmentEntity> GetBySpecifyingDate(DateTime date)
        => _appDbContext.Appointments.Where(a => a.SpecifyingDate.Equals(date));
}
