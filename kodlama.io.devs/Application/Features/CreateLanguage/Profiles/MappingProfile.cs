using Application.Features.CreateLanguage.Commands.CreateLanguage;
using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CreateLanguage.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Language , CreateLanguageCommand>().ReverseMap();
        CreateMap<Language , LanguageListDto>().ReverseMap();
        CreateMap<CreatedLanguageDto , Language>().ReverseMap();
        CreateMap<LanguageListModel , IPaginate<Language>>().ReverseMap();
    }
}