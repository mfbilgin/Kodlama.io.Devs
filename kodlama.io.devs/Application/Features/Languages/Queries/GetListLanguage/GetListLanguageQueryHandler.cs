using Application.Features.Languages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetListLanguage;

public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;


    public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Language> languages = await _languageRepository.GetListAsync(index:request.PageRequest!.Page,size:request.PageRequest.PageSize);
        LanguageListModel mappedLanguageModel = _mapper.Map<LanguageListModel>(languages);
        return mappedLanguageModel;
    }
}