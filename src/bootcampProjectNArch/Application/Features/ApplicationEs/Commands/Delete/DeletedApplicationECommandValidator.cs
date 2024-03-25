using FluentValidation;

namespace Application.Features.ApplicationEs.Commands.Delete;

public class DeleteApplicationECommandValidator : AbstractValidator<DeleteApplicationECommand>
{
    public DeleteApplicationECommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
