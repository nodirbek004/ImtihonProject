using AutoMapper;
using AutoMapper.Execution;
using Restarant.Application.DTOs.Client;
using Restarant.Application.Interfaces;
using Restarant.Application.Mappers;
using Restarant.Domain.Entities;
using Restarant.Domain.Exceptions.Admin;
using Restarant.Domain.Exceptions.Client;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Application.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ClientService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));
    }
    public async ValueTask<bool> CreateAsync(ClientCreationDto dto)
    {
        var existDoctor = await unitOfWork.ClientRepository.GetByTelNumberAsync(dto.PhoneNumber);
        if (existDoctor == null)
        {
            var mappedPatient = mapper.Map<Client>(dto);
            var result = await unitOfWork.ClientRepository.CreateAsync(mappedPatient);
            await unitOfWork.SaveAsync();
            return true;
        }
        throw new ClientAllreadyExsistException();
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existDoctor = await unitOfWork.ClientRepository.GetByIdAsync(id);
        if (existDoctor == null)
        {
            throw new ClientNotFoundException();
        }
        unitOfWork.ClientRepository.Delete(existDoctor);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Client>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.ClientRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception)
        {
            throw new ClientNotFoundException();
        }
    }

    public async ValueTask<Client> GetByIdAsync(long id)
    {
        var res = await unitOfWork.ClientRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new ClientNotFoundException();
        }
        return res;
    }

    public async ValueTask<Client> GetByPhoneNumberAsync(string number)
    {
        var res = await unitOfWork.ClientRepository.GetByTelNumberAsync(number);
        if (res == null)
        {
            throw new ClientNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(ClientUpdateDto dto)
    {
        var existPatient = await unitOfWork.ClientRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new ClientNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.ClientRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
