using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Commands.UpdateLanguage;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}