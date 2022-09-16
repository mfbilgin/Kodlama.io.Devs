using Application.Services.Auth;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auth.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public AuthBusinessRules(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
    {
        IPaginate<User> result = await _userRepository.GetListAsync(b => b.Email == email);
        if (result.Items.Any()) throw new BusinessException("User e-Mail already exists.");
    }
    public async Task UserEmailShouldExistWhenRequested(User user)
    {
        if (user == null) throw new BusinessException("Request e-Mail does not exist.");
    }

    public async Task PasswordShouldVerifyWhenRequested(string password,byte[] passwordHash, byte[] passwordSalt)
    {
        if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordHash))
            throw new BusinessException("Password error");
    }

    public async Task StatusShouldTrueWhenRequested(bool status)
    {
        if (!status) throw new BusinessException("Account was blocked.");
    }
}