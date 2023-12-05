using Poliklinika.Application.DTOs.Appointments;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Application.Interfaces;

public interface IAppointmentService
{
    ValueTask<bool> CreateAsync(AppoinmentCreationDto dto); 
    ValueTask<bool> UpdateAsync(AppoinmentUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<AppointmentEntity>> GetAllAsync();
    ValueTask<AppointmentEntity> GetByIdAsync(long id);
}
