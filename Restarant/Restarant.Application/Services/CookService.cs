using AutoMapper;
using Restarant.Application.DTOs.Cook;
using Restarant.Application.Interfaces;
using Restarant.Application.Mappers;
using Restarant.Domain.Entities;
using Restarant.Domain.Exceptions.Cook;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Application.Services;

public class CookService : ICookService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CookService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));
    }
    public async ValueTask<bool> CreateAsync(CookCreationDto dto)
    {
        var existDoctor = unitOfWork.CookRepository.SearchByName(dto.FirstName);
        if (existDoctor == null)
        {
            var mappedPatient = mapper.Map<Cook>(dto);
            var result = await unitOfWork.CookRepository.CreateAsync(mappedPatient);
            await unitOfWork.SaveAsync();
            return true;
        }
        throw new CookAllreadyExistsException();
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existDoctor = await unitOfWork.CookRepository.GetByIdAsync(id);
        if (existDoctor == null)
        {
            throw new CookNotFoundException();
        }
        unitOfWork.CookRepository.Delete(existDoctor);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Cook>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.CookRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception)
        {
            throw new CookNotFoundException();
        }
    }

    public async ValueTask<Cook> GetByIdAsync(long id)
    {
        var res = await unitOfWork.CookRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new CookNotFoundException();
        }
        return res;
    }

    public ValueTask<Cook> GetByNameAsync()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(CookUpdateDto dto)
    {
        var existPatient = await unitOfWork.CookRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new CookNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.CookRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
