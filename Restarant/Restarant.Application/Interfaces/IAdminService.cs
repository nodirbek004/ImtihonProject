using Restarant.Application.DTOs.Admin;
using Restarant.Domain.Entities;

namespace Restarant.Application.Interfaces;

public interface IAdminService
{
    ValueTask<bool> CreateAsync(AdminCreationDto dto);
    ValueTask<bool> UpdateAsync(AdminUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<Admin>> GetAllAsync();
    ValueTask<Admin> GetByIdAsync(long id);
    ValueTask<Admin> GetByPhoneNumberAsync(string number);


}
