using Core.Security.JWT;

namespace Application.Features.Auth.Dtos;

public class RegisteredDto
{
    public AccessToken AccessToken { get; set; }
}