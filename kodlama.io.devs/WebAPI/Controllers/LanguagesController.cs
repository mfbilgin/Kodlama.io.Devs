using Application.Features.CreateLanguage.Commands.CreateLanguage;
using Application.Features.CreateLanguage.Dtos;
using Application.Features.CreateLanguage.Models;
using Application.Features.CreateLanguage.Queries.GetListLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator!.Send(createLanguageCommand);
            return Created("",result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);

        }
    }
}
