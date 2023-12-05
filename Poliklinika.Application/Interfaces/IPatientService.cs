using Poliklinika.Application.DTOs.Patients;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Application.Interfaces;

public interface IPatientService
{
    ValueTask<PatientEntity> CreateAsync(PatientCreationDto patientCreationDto);
    ValueTask<bool> UpdateAsync(PatientUpdateDto updateDto);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<PatientEntity> GetByIdAsync(long Id);
    ValueTask<IEnumerable<PatientEntity>> GetAllAsync();
    ValueTask<PatientEntity> GetByNameAsync(string Name);

}
