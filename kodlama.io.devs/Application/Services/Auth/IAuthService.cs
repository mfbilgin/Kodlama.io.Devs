﻿using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.Auth;

public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(User user);
}