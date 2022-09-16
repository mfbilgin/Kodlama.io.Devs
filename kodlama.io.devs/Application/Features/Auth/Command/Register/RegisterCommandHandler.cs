using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using Core.Security.Enums;
using MediatR;

namespace Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(IUserRepository userRepository,
        IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository,
        IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        User mappedUser = _mapper.Map<User>(request);
        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;
        mappedUser.Status = true;
        mappedUser.AuthenticatorType = AuthenticatorType.None;
        
        User createdUser = await _userRepository.AddAsync(mappedUser);
        
        OperationClaim operationClaim = (await _operationClaimRepository.GetAsync(o => o.Name == "User"))!;
        UserOperationClaim userOperationClaim = new() { UserId = createdUser.Id, OperationClaimId = operationClaim.Id };
        await _userOperationClaimRepository.AddAsync(userOperationClaim);
        AccessToken accessToken =await _authService.CreateAccessToken(createdUser);
        RegisteredDto registeredDto = new RegisteredDto
        {
            AccessToken = accessToken
        };
        
        return registeredDto;
    }
}