using AutoMapper;
using Poliklinika.Application.DTOs.Doctors;
using Poliklinika.Application.DTOs.Patients;
using Poliklinika.Application.Interfaces;
using Poliklinika.Application.Mappers;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;
using Poliklinka.Domain.Exceptions.Doctor;
using Poliklinka.Domain.Exceptions.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DoctorService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));

    }
    public async ValueTask<DoctorEntity> CreateAsync(DoctorCreationDto dto)
    {

         var existDoctor = await unitOfWork.DoctorRepository.GetByTelNumberAsync(dto.TelNumber);
            if (existDoctor == null)
            {
                var mappedPatient = mapper.Map<DoctorEntity>(dto);
                var result = await unitOfWork.DoctorRepository.CreateAsync(mappedPatient);
                await unitOfWork.SaveAsync();
                return result;
            }
            throw new DoctorAlreadyExistsException();



    }

    public async ValueTask<bool> DeleteAsync(long id)
    { 
        var existDoctor=await unitOfWork.DoctorRepository.GetByIdAsync(id);
        if (existDoctor == null)
        {
            throw new DoctorNotFoundException();
        }
        unitOfWork.DoctorRepository.Delete(existDoctor);
        unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<DoctorEntity>> GetAllAsync()
    {
        try
        {
            var existPatient =  unitOfWork.DoctorRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception ex)
        {
            throw new DoctorNotFoundException();
        }
    }

    public async ValueTask<DoctorEntity> GetByIdAsync(long id)
    {
        var res = await unitOfWork.DoctorRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new DoctorNotFoundException();
        }
        return res;

    }

    public async ValueTask<DoctorEntity> GetByTelNumber(string number)
    {
        var res = await unitOfWork.DoctorRepository.GetByTelNumberAsync(number);
        if(res == null)
        {
            throw new DoctorNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(DoctorUpdateDto dto)
    {
        var existPatient = await unitOfWork.DoctorRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new DoctorNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.DoctorRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;

    }
}
