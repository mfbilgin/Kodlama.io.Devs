using Application.Features.CreateLanguage.Commands.CreateLanguage;
using Application.Features.CreateLanguage.Commands.DeleteLanguage;
using Application.Features.CreateLanguage.Commands.UpdateLanguage;
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
        CreateMap<Language , DeleteLanguageCommand>().ReverseMap();
        CreateMap<Language , UpdateLanguageCommand>().ReverseMap();
        CreateMap<Language , LanguageListDto>().ReverseMap();
        CreateMap<Language , LanguageGetByIdDto>().ReverseMap();
        CreateMap<Language , DeletedLanguageDto>().ReverseMap();
        CreateMap<Language , CreatedLanguageDto>().ReverseMap();
        CreateMap<Language , UpdatedLanguageDto>().ReverseMap();
        CreateMap<LanguageListModel , IPaginate<Language>>().ReverseMap();
    }
}