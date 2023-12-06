using Restarant.Application.DTOs.Admin;
using Restarant.Application.DTOs.Client;
using Restarant.Domain.Entities;

namespace Restarant.Application.Interfaces;

public interface IClientService
{
    ValueTask<bool> CreateAsync(ClientCreationDto dto);
    ValueTask<bool> UpdateAsync(ClientUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<Client>> GetAllAsync();
    ValueTask<Client> GetByIdAsync(long id);
    ValueTask<Client> GetByPhoneNumberAsync(string number);
}
