﻿using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Commands.CreateLanguage;

public class CreateLanguageCommand : IRequest<CreatedLanguageDto>
{
    public string? Name { get; set; }
    
}