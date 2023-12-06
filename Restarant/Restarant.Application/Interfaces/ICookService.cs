using Restarant.Application.DTOs.Admin;
using Restarant.Application.DTOs.Cook;
using Restarant.Domain.Entities;

namespace Restarant.Application.Interfaces;

public interface ICookService
{
    ValueTask<bool> CreateAsync(CookCreationDto dto);
    ValueTask<bool> UpdateAsync(CookUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<Cook>> GetAllAsync();
    ValueTask<Cook> GetByIdAsync(long id);
    ValueTask<Cook> GetByNameAsync();
}
