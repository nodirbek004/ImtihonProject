using AutoMapper;
using Poliklinika.Application.DTOs.MedicalRecords;
using Poliklinika.Application.Interfaces;
using Poliklinika.Application.Mappers;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;
using Poliklinka.Domain.Exceptions.Appointment;
using Poliklinka.Domain.Exceptions.MedicalRecord;

namespace Poliklinika.Application.Services;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MedicalRecordService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));
    }

    public async ValueTask<bool> CreateAsync(MedicalRecordCreationDto dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(dto.PatientId);

        if (existPatient is null)
        {
            return false;
        }


        var mappedMedicalRecord = mapper.Map<MedicalRecord>(dto);

        await unitOfWork.MedicalRecordRepository.CreateAsync(mappedMedicalRecord);
        var temp = await unitOfWork.MedicalRecordRepository.SaveAsync();

        var result = mapper.Map<MedicalRecord>(mappedMedicalRecord);
        return true;

    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAppointment = await unitOfWork.MedicalRecordRepository.GetByIdAsync(id);

        if (existAppointment is null)
        {
            return false;
        }


        unitOfWork.MedicalRecordRepository.Delete(existAppointment);
        await unitOfWork.MedicalRecordRepository.SaveAsync();
        return true;
    }

    public  async ValueTask<IEnumerable<MedicalRecord>> GetAllAsync()
    {
        try
        {
            var existPatient = unitOfWork.MedicalRecordRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception ex)
        {
            throw new MedicalRecordNotFoundException();
        }
    }

    public async ValueTask<MedicalRecord> GetByIdAsync(long id)
    {
        var res = await unitOfWork.MedicalRecordRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new MedicalRecordNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(MedicalRecordUpdateDto dto)
    {
        var existPatient = await unitOfWork.MedicalRecordRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new MedicalRecordNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.MedicalRecordRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
