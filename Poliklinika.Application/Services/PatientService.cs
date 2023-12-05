using AutoMapper;
using Poliklinika.Application.DTOs.Patients;
using Poliklinika.Application.Interfaces;
using Poliklinika.Application.Mappers;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;
using Poliklinka.Domain.Exceptions.Patient;

namespace Poliklinika.Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public PatientService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
    ));
    }

    public async ValueTask<PatientEntity> CreateAsync(PatientCreationDto patientCreationDto)
    {
        try
        {
            var existPatient = await unitOfWork.PatientRepository.GetByTelNumber(patientCreationDto.TelNumber);
            if (existPatient == null)
            {
            var mappedPatient= mapper.Map<PatientEntity>(patientCreationDto);
            var result = await unitOfWork.PatientRepository.CreateAsync(mappedPatient);
            await unitOfWork.SaveAsync();
            return result;
            }
            else
            {
                throw new PatientAlreadyExistsException();

            }
        }
        catch (Exception ex) 
        {
            return null;
        }
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        var res= await  unitOfWork.PatientRepository.GetByIdAsync(Id);
        if(res == null)
        {
            throw new PatientNotFoundException();
        }
        unitOfWork.PatientRepository.Delete(res);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<PatientEntity>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.PatientRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception ex)
        {
            throw new PatientNotFoundException();
        }
    }

    public async ValueTask<PatientEntity> GetByIdAsync(long Id)
    {
        var res =await unitOfWork.PatientRepository.GetByIdAsync(Id);
        if(res == null)
        {
            throw new PatientNotFoundException();
        }
        return res;
    }

    public async ValueTask<PatientEntity> GetByNameAsync(string Name)
    {
        var res=unitOfWork.PatientRepository.SearchByName(Name);
        if(res == null)
        {
            throw new PatientNotFoundException();
        }

        return (PatientEntity)res;
    }

    public async ValueTask<bool> UpdateAsync(PatientUpdateDto updateDto)
    {
        var existPatient=await unitOfWork.PatientRepository.GetByIdAsync(updateDto.Id);
        if (existPatient == null)
        {
            throw new PatientNotFoundException();
        }
        var mappedPatient = mapper.Map(updateDto, existPatient);

        var result = unitOfWork.PatientRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;

    }
}
