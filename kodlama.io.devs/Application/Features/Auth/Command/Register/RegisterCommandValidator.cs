using FluentValidation;

namespace Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Email).EmailAddress().MinimumLength(10).NotEmpty();
        RuleFor(r => r.Password).NotEmpty().MinimumLength(6);
        RuleFor(r => r.FirstName).NotEmpty().MinimumLength(3);
        RuleFor(r => r.LastName).NotEmpty().MinimumLength(3);
    }
}