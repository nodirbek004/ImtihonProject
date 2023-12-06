using AutoMapper;
using AutoMapper.Execution;
using Restarant.Application.DTOs.Waiter;
using Restarant.Application.Interfaces;
using Restarant.Application.Mappers;
using Restarant.Domain.Entities;
using Restarant.Domain.Exceptions.Admin;
using Restarant.Domain.Exceptions.Waiter;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Application.Services;

public class WaiterService : IWaiterService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public WaiterService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));
    }
    public async ValueTask<bool> CreateAsync(WaiterCreationDto dto)
    {
        var existDoctor = await unitOfWork.WaiterRepository.GetByTelNumberAsync(dto.PhoneNumber);
        if (existDoctor == null)
        {
            var mappedPatient = mapper.Map<Waiter>(dto);
            var result = await unitOfWork.WaiterRepository.CreateAsync(mappedPatient);
            await unitOfWork.SaveAsync();
            return true;
        }
        throw new WaiterAllreadyExistsException();
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existDoctor = await unitOfWork.WaiterRepository.GetByIdAsync(id);
        if (existDoctor == null)
        {
            throw new WaiterNotFoundException();
        }
        unitOfWork.WaiterRepository.Delete(existDoctor);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Waiter>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.WaiterRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception)
        {
            throw new WaiterNotFoundException();
        }
    }

    public async ValueTask<Waiter> GetByIdAsync(long id)
    {
        var res = await unitOfWork.WaiterRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new WaiterNotFoundException();
        }
        return res;
    }

    public async ValueTask<Waiter> GetByPhoneNumberAsync(string number)
    {
        var res = await unitOfWork.WaiterRepository.GetByTelNumberAsync(number);
        if (res == null)
        {
            throw new WaiterNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(WaiterUpdateDto dto)
    {
        var existPatient = await unitOfWork.WaiterRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new WaiterNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.WaiterRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
