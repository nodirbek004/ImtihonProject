using AutoMapper;
using Restarant.Application.DTOs.Admin;
using Restarant.Application.Interfaces;
using Restarant.Application.Mappers;
using Restarant.Domain.Entities;
using Restarant.Domain.Exceptions.Admin;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public AdminService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));

    }

    public async ValueTask<bool> CreateAsync(AdminCreationDto dto)
    {
        var existDoctor = await unitOfWork.AdminRepository.GetByTelNumberAsync(dto.PhoneNumber);
        if (existDoctor == null)
        {
            var mappedPatient = mapper.Map<Admin>(dto);
            var result = await unitOfWork.AdminRepository.CreateAsync(mappedPatient);
            await unitOfWork.SaveAsync();
            return true;
        }
        throw new AdminAllreadyExsistException();
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existDoctor = await unitOfWork.AdminRepository.GetByIdAsync(id);
        if (existDoctor == null)
        {
            throw new AdminNotFoundException();
        }
        unitOfWork.AdminRepository.Delete(existDoctor);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Admin>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.AdminRepository.GetAllAsync();
            return existPatient;
        }
        catch (Exception)
        {
            throw new AdminNotFoundException();
        }
    }

    public async ValueTask<Admin> GetByIdAsync(long id)
    {
        var res = await unitOfWork.AdminRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new AdminNotFoundException();
        }
        return res;
    }

    public async ValueTask<Admin> GetByPhoneNumberAsync(string number)
    {
        var res = await unitOfWork.AdminRepository.GetByTelNumberAsync(number);
        if (res == null)
        {
            throw new AdminNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(AdminUpdateDto dto)
    {
        var existPatient = await unitOfWork.AdminRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new AdminNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.AdminRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
