using Application.Features.Auth.Dtos;
using MediatR;

namespace Application.Features.Auth.Command.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}