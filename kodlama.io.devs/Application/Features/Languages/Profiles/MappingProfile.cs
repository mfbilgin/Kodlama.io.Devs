using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Profiles;

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