using AutoMapper;
using Poliklinika.Application.DTOs.Appointments;
using Poliklinika.Application.Interfaces;
using Poliklinika.Application.Mappers;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinka.Domain.Entities;
using Poliklinka.Domain.Exceptions.Appointment;
using Poliklinka.Domain.Exceptions.Doctor;

namespace Poliklinika.Application.Services;

public class AppontmentService : IAppointmentService
{
    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;

    public AppontmentService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = new Mapper(new MapperConfiguration(
        cfg => cfg.AddProfile<MappingProfile>()
        ));
    }
    public async ValueTask<bool> CreateAsync(AppoinmentCreationDto dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(dto.PatientId);
        var existDoctor = await unitOfWork.DoctorRepository.GetByIdAsync(dto.DoctorId);

        if (existPatient is null || existDoctor is null)
        {
            return false;
        }


        var mappedAppointment = mapper.Map<AppointmentEntity>(dto);

        await unitOfWork.AppointmentRepository.CreateAsync(mappedAppointment);
        var temp = await unitOfWork.AppointmentRepository.SaveAsync();

        var result = mapper.Map<AppointmentEntity>(mappedAppointment);
        return true;

    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAppointment = await unitOfWork.AppointmentRepository.GetByIdAsync(id);

        if (existAppointment is null)
        {
            return false;
        }


        unitOfWork.AppointmentRepository.Delete(existAppointment);
        await unitOfWork.AppointmentRepository.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<AppointmentEntity>> GetAllAsync()
    {
        try
        {
            var existPatient =  unitOfWork.AppointmentRepository.GetAllAsync();
            return existPatient;

        }
        catch (Exception ex)
        {
            throw new AppointmentNotFoundException();
        }
    }

    public async ValueTask<AppointmentEntity> GetByIdAsync(long id)
    {
        var res = await unitOfWork.AppointmentRepository.GetByIdAsync(id);
        if (res == null)
        {
            throw new AppointmentNotFoundException();
        }
        return res;
    }

    public async ValueTask<bool> UpdateAsync(AppoinmentUpdateDto dto)
    {
        var existPatient = await unitOfWork.AppointmentRepository.GetByIdAsync(dto.Id);
        if (existPatient == null)
        {
            throw new AppointmentNotFoundException();
        }
        var mappedPatient = mapper.Map(dto, existPatient);

        var result = unitOfWork.AppointmentRepository.Update(mappedPatient);
        await unitOfWork.SaveAsync();
        return true;
    }
}
