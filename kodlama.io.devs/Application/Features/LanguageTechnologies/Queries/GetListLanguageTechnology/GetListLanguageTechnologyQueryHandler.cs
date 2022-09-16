using Application.Features.LanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;

public class
    GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
{
    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
    private readonly IMapper _mapper;

    public GetListLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository,
        IMapper mapper)
    {
        _languageTechnologyRepository = languageTechnologyRepository;
        _mapper = mapper;
    }

    public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request,
        CancellationToken cancellationToken)
    {
        IPaginate<LanguageTechnology> technologies = await _languageTechnologyRepository.GetListAsync(include:
            m => m.Include(c => c.Language),
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize
        );
        LanguageTechnologyListModel mappedTechnology = _mapper.Map<LanguageTechnologyListModel>(technologies);
        return mappedTechnology;
    }
}