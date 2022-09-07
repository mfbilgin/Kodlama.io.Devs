using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Commands.DeleteLanguage;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand,DeletedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;


    public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        Language? language = await _languageRepository.GetAsync(language => language.Id == request.Id);
        await _languageBusinessRules.LanguageShouldExistWhenRequested(language!);
            
        Language deletedLanguage = await _languageRepository.DeleteAsync(language!);
        DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

        return deletedLanguageDto;
    }
}