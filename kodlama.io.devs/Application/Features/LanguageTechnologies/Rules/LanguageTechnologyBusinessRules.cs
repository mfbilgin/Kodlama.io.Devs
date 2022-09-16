using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.LanguageTechnologies.Rules;

public class LanguageTechnologyBusinessRules
{
    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

    public LanguageTechnologyBusinessRules(ILanguageTechnologyRepository languageTechnologyRepository)
    {
        _languageTechnologyRepository = languageTechnologyRepository;
    }
    public async Task LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(string? name)
    {
        IPaginate<LanguageTechnology> result = await _languageTechnologyRepository.GetListAsync(technology => technology.Name== name);
        if (result.Items.Any()) throw new BusinessException("Language technology name exists.");
    }
    public async Task LanguageTechnologyShouldExistWhenRequested(LanguageTechnology languageTechnology)
    {
        if (languageTechnology == null) throw new BusinessException("Requested language technology does not exist.");
    }
    public async Task LanguageShouldExistWhenRequested(Language language)
    {
        if (language == null) throw new BusinessException("Requested language does not exist.");
    }
}