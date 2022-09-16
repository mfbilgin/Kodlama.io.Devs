using Application.Features.LanguageTechnologies.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;

public class GetListLanguageTechnologyQuery : IRequest<LanguageTechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}