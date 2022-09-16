using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand,DeletedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;


    public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules, ILanguageTechnologyRepository languageTechnologyRepository)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
        _languageTechnologyRepository = languageTechnologyRepository;
    }

    public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        IList<LanguageTechnology> languageTechnologies = _languageTechnologyRepository.GetAll(technology => technology.LanguageId == request.Id);
        for (int i = 0; i < languageTechnologies.Count; i++)
        {
            _languageTechnologyRepository.DeleteAsync(languageTechnologies[i]);
        }
        Language? language = await _languageRepository.GetAsync(language => language.Id == request.Id);
        await _languageBusinessRules.LanguageShouldExistWhenRequested(language!);
            
        Language deletedLanguage = await _languageRepository.DeleteAsync(language!);
        DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

        return deletedLanguageDto;
    }
}