using Application.Features.Auth.Command.Login;
using Application.Features.Auth.Command.Register;
using Application.Features.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        RegisteredDto result = await Mediator.Send(registerCommand);
        return Created("", result.AccessToken);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        LoginedDto result = await Mediator.Send(loginCommand);
        return Created("", result.AccessToken);
    }
}