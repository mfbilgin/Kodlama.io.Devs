using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Models;
using MediatR;

namespace Application.Features.CreateLanguage.Queries.GetByIdLanguage;

public class GetByIdLanguageQuery : IRequest<LanguageGetByIdDto>
{
    public int Id { get; set; }
}