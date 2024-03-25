using FluentValidation;

namespace Application.Features.ApplicationEs.Commands.Update;

public class UpdateApplicationECommandValidator : AbstractValidator<UpdateApplicationECommand>
{
    public UpdateApplicationECommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ApplicationStateId).NotEmpty();
    }
}
