using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage;

public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery,LanguageGetByIdDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;
    
    public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
    {
        Language? language = await _languageRepository.GetAsync(language => language.Id == request.Id);
        await _languageBusinessRules.LanguageShouldExistWhenRequested(language!);
        LanguageGetByIdDto mappedLanguageGet = _mapper.Map<LanguageGetByIdDto>(language);
        return mappedLanguageGet;
    }
}