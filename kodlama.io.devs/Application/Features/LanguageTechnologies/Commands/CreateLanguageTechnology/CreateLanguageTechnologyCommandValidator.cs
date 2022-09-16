using Domain.Entities;
using FluentValidation;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;

public class CreateLanguageTechnologyCommandValidator : AbstractValidator<LanguageTechnology>
{
    public CreateLanguageTechnologyCommandValidator()
    {
        RuleFor(technology => technology.Name).NotEmpty();
        RuleFor(technology => technology.Name).MinimumLength(2);
    }
}