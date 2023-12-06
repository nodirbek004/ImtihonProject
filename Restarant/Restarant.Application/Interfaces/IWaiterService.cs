using Restarant.Application.DTOs.Admin;
using Restarant.Application.DTOs.Waiter;
using Restarant.Domain.Entities;

namespace Restarant.Application.Interfaces;

public interface IWaiterService
{
    ValueTask<bool> CreateAsync(WaiterCreationDto dto);
    ValueTask<bool> UpdateAsync(WaiterUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<Waiter>> GetAllAsync();
    ValueTask<Waiter> GetByIdAsync(long id);
    ValueTask<Waiter> GetByPhoneNumberAsync(string number);
}
