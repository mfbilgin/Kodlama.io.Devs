using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechnologies.Dtos;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;

public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
{
    public int Id { get; set; }
}