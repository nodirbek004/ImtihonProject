using AutoMapper;
using Poliklinika.Application.DTOs.Appointments;
using Poliklinika.Application.DTOs.Doctors;
using Poliklinika.Application.DTOs.MedicalRecords;
using Poliklinika.Application.DTOs.Patients;
using Poliklinka.Domain.Entities;
using System.Runtime.InteropServices;

namespace Poliklinika.Application.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Patient
        CreateMap<PatientEntity,PatientCreationDto>().ReverseMap();
        CreateMap<PatientEntity,PatientUpdateDto>().ReverseMap();

        //Doctor
        CreateMap<DoctorEntity,DoctorCreationDto>().ReverseMap();
        CreateMap<DoctorEntity, DoctorUpdateDto>().ReverseMap();

        //Appointment
        CreateMap<AppointmentEntity, AppoinmentCreationDto>().ReverseMap();
        CreateMap<AppointmentEntity, AppoinmentUpdateDto>().ReverseMap();

        //MedicalRecord
        CreateMap<MedicalRecord, MedicalRecordCreationDto>().ReverseMap();
        CreateMap<MedicalRecord, MedicalRecordUpdateDto>().ReverseMap();
    }
}
