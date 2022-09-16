using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.LanguageTechnologies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
        CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();
        CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
        
        CreateMap<LanguageTechnology, LanguageTechnologyListModel>().ReverseMap();
        CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(t => t.LanguageName,opt => opt.MapFrom(l => l.Language.Name)).ReverseMap();
        CreateMap<LanguageTechnologyListModel, IPaginate<LanguageTechnology>>().ReverseMap();

        CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
        CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
        CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
        
    }
}