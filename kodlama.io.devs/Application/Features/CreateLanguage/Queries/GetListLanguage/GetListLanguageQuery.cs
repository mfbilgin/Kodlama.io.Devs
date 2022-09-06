using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Queries.GetListLanguage;

public class GetListLanguageQuery : IRequest<LanguageListModel>
{
    public PageRequest? PageRequest { get; set; }

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
            IPaginate<Language> languages = await _languageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
            LanguageListModel mappedLanguageModel = _mapper.Map<LanguageListModel>(languages);
            return mappedLanguageModel;
        }
    }

}