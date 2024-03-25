using FluentValidation;

namespace Application.Features.ApplicationEs.Commands.Create;

public class CreateApplicationECommandValidator : AbstractValidator<CreateApplicationECommand>
{
    public CreateApplicationECommandValidator()
    {
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ApplicationStateId).NotEmpty();
    }
}
