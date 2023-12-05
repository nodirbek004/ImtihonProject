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

    public async ValueTask<bool> DeleteAsync(int Id)
    {
        var res= await  unitOfWork.PatientRepository.GetByIdAsync(Id);
        if(res == null)
        {
            throw new PatientNotFoundException();
        }
        unitOfWork.PatientRepository.Delete(res);
        unitOfWork.SaveAsync();
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

    public ValueTask<PatientEntity> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PatientEntity> GetByNameAsync(string Name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PatientEntity> UpdateAsync(PatientUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}
