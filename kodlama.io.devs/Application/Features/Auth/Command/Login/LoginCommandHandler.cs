using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Command.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand,LoginedDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User userGetById = await _userRepository.GetAsync(u => u.Email == request.Email);
        await _authBusinessRules.UserEmailShouldExistWhenRequested(userGetById);
        await _authBusinessRules.PasswordShouldVerifyWhenRequested(request.Password, userGetById.PasswordHash,
            userGetById.PasswordSalt);
        await _authBusinessRules.StatusShouldTrueWhenRequested(userGetById.Status);
        AccessToken accessToken =await _authService.CreateAccessToken(userGetById);
        LoginedDto loginedDto = new LoginedDto
        {
            AccessToken = accessToken
        };
        return loginedDto;
    }
}