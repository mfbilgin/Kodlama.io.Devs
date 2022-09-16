using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommandHanlder : IRequestHandler<CreateLanguageCommand,CreatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;


    public CreateLanguageCommandHanlder(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

        Language mappedLanguage = _mapper.Map<Language>(request);
        Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
        CreatedLanguageDto createdLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);

        return createdLanguageDto;
    }
}