using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(language => language.Name).NotEmpty().WithMessage("Language name not be empty.");
    }
}