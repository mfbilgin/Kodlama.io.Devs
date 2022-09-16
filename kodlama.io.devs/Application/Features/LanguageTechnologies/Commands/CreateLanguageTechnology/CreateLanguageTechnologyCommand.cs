using Application.Features.LanguageTechnologies.Dtos;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;

public class CreateLanguageTechnologyCommand : IRequest<CreatedLanguageTechnologyDto>
{
    public string Name { get; set; }
    public int LanguageId { get; set; }
    
}