using System.Linq.Dynamic.Core;
using Application.Features.LanguageTechnologies.Dtos;
using Core.Application.Requests;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;

public class UpdateLanguageTechnologyCommand : IRequest<UpdatedLanguageTechnologyDto>
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
}