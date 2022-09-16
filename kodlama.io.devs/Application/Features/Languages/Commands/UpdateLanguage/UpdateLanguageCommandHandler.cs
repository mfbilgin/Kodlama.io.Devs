using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;


    public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        Language? languageGetById = await _languageRepository.GetAsync(language => language.Id == request.Id);
        await _languageBusinessRules.LanguageShouldExistWhenRequested(languageGetById!);
        await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
        
        languageGetById!.Name = request.Name!;
        Language updatedLanguage = await _languageRepository.UpdateAsync(languageGetById);
        UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);
        
        return updatedLanguageDto;
    }
}