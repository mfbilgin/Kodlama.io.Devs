using Core.Security.JWT;

namespace Application.Features.Auth.Dtos;

public class LoginedDto
{
    public AccessToken AccessToken { get; set; }
}