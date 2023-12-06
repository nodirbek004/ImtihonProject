using AutoMapper;
using Restarant.Application.DTOs.Admin;
using Restarant.Application.DTOs.Client;
using Restarant.Application.DTOs.Cook;
using Restarant.Application.DTOs.Waiter;
using Restarant.Domain.Entities;

namespace Restarant.Application.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Admin
        CreateMap<Admin,AdminCreationDto>().ReverseMap();
        CreateMap<Admin,AdminUpdateDto>().ReverseMap();

        //Cook
        CreateMap<Cook,CookCreationDto>().ReverseMap();
        CreateMap<Cook, CookUpdateDto>().ReverseMap();

        //Client
        CreateMap<Client,ClientCreationDto>().ReverseMap(); 
        CreateMap<Client, ClientUpdateDto>().ReverseMap();

        //Waiter
        CreateMap<Waiter, WaiterCreationDto>().ReverseMap();
        CreateMap<Waiter, WaiterUpdateDto>().ReverseMap();
    }
}
