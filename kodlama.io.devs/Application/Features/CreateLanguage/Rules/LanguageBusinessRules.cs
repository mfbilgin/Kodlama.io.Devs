using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CreateLanguage.Rules;

public class LanguageBusinessRules
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageBusinessRules(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }
    public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string? name)
    {
        IPaginate<Language> result = await _languageRepository.GetListAsync(language => language.Name== name);
        if (result.Items.Any()) throw new BusinessException("Brand name exists.");
    }
}