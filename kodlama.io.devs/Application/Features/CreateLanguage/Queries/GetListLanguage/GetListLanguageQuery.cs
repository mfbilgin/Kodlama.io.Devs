using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreateLanguage.Queries.GetListLanguage;

public class GetListLanguageQuery : IRequest<LanguageListModel>
{
    public PageRequest? PageRequest { get; set; }

    

}