using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(language => language.Name).NotEmpty();
    }
}