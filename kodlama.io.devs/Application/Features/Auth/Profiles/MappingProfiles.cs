using Application.Features.Auth.Command.Register;
using Application.Features.Auth.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, RegisteredDto>().ReverseMap();
        CreateMap<User, RegisterCommand>().ReverseMap();
    }   
}