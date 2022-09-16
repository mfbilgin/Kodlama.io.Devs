using Application.Features.Auth.Dtos;
using MediatR;

namespace Application.Features.Auth.Command.Login;

public class LoginCommand : IRequest<LoginedDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}