using Core.Persistence.Repositories;

namespace Core.Security.JWT;

public class AccessToken : Entity
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}