using Poliklinika.Application.DTOs.Patients;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Application.Interfaces;

public interface IPatientService
{
    ValueTask<PatientEntity> CreateAsync(PatientCreationDto patientCreationDto);
    ValueTask<PatientEntity> UpdateAsync(PatientUpdateDto updateDto);
    ValueTask<bool> DeleteAsync(int Id);
    ValueTask<PatientEntity> GetByIdAsync(int Id);
    ValueTask<IEnumerable<PatientEntity>> GetAllAsync();
    ValueTask<PatientEntity> GetByNameAsync(string Name);

}
