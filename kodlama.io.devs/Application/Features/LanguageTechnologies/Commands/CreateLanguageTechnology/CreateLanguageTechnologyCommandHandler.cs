using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;

public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand,CreatedLanguageTechnologyDto>
{
    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;

    public CreateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper, LanguageTechnologyBusinessRules languageTechnologyBusinessRules, ILanguageRepository languageRepository)
    {
        _languageTechnologyRepository = languageTechnologyRepository;
        _mapper = mapper;
        _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        _languageRepository = languageRepository;
    }

    public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
    {
        Language language = await _languageRepository.GetAsync(language => language.Id == request.LanguageId);
        await _languageTechnologyBusinessRules.LanguageShouldExistWhenRequested(language);
        LanguageTechnology mappedLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
        await _languageTechnologyBusinessRules.LanguageTechnologyShouldExistWhenRequested(mappedLanguageTechnology);
        LanguageTechnology createdLanguageTechnology = await _languageTechnologyRepository.AddAsync(mappedLanguageTechnology);
        CreatedLanguageTechnologyDto createdLanguageTechnologyDto =
            _mapper.Map<CreatedLanguageTechnologyDto>(createdLanguageTechnology);
        return createdLanguageTechnologyDto;
    }
}