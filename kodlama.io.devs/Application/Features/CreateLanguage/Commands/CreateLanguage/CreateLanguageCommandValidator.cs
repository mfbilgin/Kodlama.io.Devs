using FluentValidation;

namespace Application.Features.CreateLanguage.Commands.CreateLanguage;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(language => language.Name).NotEmpty().WithMessage("Language name not be empty.");
    }
}