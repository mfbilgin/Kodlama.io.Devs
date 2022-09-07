using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
{
    public int Id { get; set; }
}