using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LanguageTechnologiesController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
    {
        CreatedLanguageTechnologyDto result = await Mediator!.Send(createLanguageTechnologyCommand);
        return Ok(result);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand)
    {
        UpdatedLanguageTechnologyDto result = await Mediator!.Send(updateLanguageTechnologyCommand);
        return Ok(result);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
    {
        DeletedLanguageTechnologyDto result = await Mediator!.Send(deleteLanguageTechnologyCommand);
        return Ok(result);
    }
    [HttpGet("getList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageTechnologyQuery getListLanguageTechnology = new() { PageRequest = pageRequest };
        LanguageTechnologyListModel result = await Mediator!.Send(getListLanguageTechnology);
        return Ok(result);

    }
}