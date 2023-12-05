using AutoMapper;
using Poliklinika.Application.DTOs.Patients;
using Poliklinka.Domain.Entities;
using System.Runtime.InteropServices;

namespace Poliklinika.Application.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<PatientEntity,PatientCreationDto>().ReverseMap();
        CreateMap<PatientEntity,PatientUpdateDto>().ReverseMap();
    }
}
