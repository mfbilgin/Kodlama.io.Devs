using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;

public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand,DeletedLanguageTechnologyDto>
{

    private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
    private readonly IMapper _mapper;
    private readonly LanguageTechnologyBusinessRules _businessRules;

    public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper, LanguageTechnologyBusinessRules businessRules)
    {
        _languageTechnologyRepository = languageTechnologyRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
    {
        LanguageTechnology? technologyById = await _languageTechnologyRepository.GetAsync(technology => technology.Id == request.Id);
        await _businessRules.LanguageTechnologyShouldExistWhenRequested(technologyById!);
        
        LanguageTechnology deletedTechnology = await _languageTechnologyRepository.DeleteAsync(technologyById!);
        DeletedLanguageTechnologyDto deletedLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(deletedTechnology);
        return deletedLanguageTechnologyDto;

    }
}