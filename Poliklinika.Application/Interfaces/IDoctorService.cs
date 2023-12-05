using Poliklinika.Application.DTOs.Doctors;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Application.Interfaces;

public interface IDoctorService
{
    ValueTask<DoctorEntity> CreateAsync(DoctorCreationDto dto);
    ValueTask<bool> UpdateAsync(DoctorUpdateDto dto);
    ValueTask<bool> DeleteAsync(long  id);
    ValueTask<DoctorEntity> GetByIdAsync(long id);
    ValueTask<IEnumerable<DoctorEntity>> GetAllAsync();
    ValueTask<DoctorEntity> GetByTelNumber(string number); 
}
