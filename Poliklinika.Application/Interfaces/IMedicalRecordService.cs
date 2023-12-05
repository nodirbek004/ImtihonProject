using Poliklinika.Application.DTOs.Appointments;
using Poliklinika.Application.DTOs.MedicalRecords;
using Poliklinka.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.Interfaces
{
    public interface IMedicalRecordService
    {
        ValueTask<bool> CreateAsync(MedicalRecordCreationDto dto);
        ValueTask<bool> UpdateAsync(MedicalRecordUpdateDto dto);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<IEnumerable<MedicalRecord>> GetAllAsync();
        ValueTask<MedicalRecord> GetByIdAsync(long id);
    }
}
