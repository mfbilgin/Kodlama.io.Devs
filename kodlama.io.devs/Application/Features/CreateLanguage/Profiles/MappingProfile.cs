using Application.Features.CreateLanguage.Commands.CreateLanguage;
using Application.Features.CreateLanguage.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CreateLanguage.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Language , CreateLanguageCommand>().ReverseMap();
        CreateMap<CreatedLanguageDto , Language>().ReverseMap();
    }
}