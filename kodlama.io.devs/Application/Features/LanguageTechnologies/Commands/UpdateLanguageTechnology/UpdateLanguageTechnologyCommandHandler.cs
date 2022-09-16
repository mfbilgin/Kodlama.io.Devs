using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;

public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand,UpdatedLanguageTechnologyDto>
{
    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageTechnologyBusinessRules _businessRules;

    public UpdateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper, LanguageTechnologyBusinessRules businessRules, ILanguageRepository languageRepository)
    {
        _languageTechnologyRepository = languageTechnologyRepository;
        _mapper = mapper;
        _businessRules = businessRules;
        _languageRepository = languageRepository;
    }

    public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
    {
        LanguageTechnology technologyById = await _languageTechnologyRepository.GetAsync(technology => technology.Id == request.Id);
        await _businessRules.LanguageTechnologyShouldExistWhenRequested(technologyById);
        await _businessRules.LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
        Language languageById = await _languageRepository.GetAsync(language => language.Id == request.LanguageId);
        await _businessRules.LanguageShouldExistWhenRequested(languageById);
        
        
        technologyById.Name = request.Name;
        technologyById.LanguageId = request.LanguageId;
        LanguageTechnology updatedTechnology = await _languageTechnologyRepository.UpdateAsync(technologyById);
        UpdatedLanguageTechnologyDto updatedLanguageTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(updatedTechnology);
        return updatedLanguageTechnologyDto;
    }
}