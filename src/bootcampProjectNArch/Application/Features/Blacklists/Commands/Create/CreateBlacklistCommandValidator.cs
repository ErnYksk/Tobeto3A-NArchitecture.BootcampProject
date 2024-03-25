using FluentValidation;

namespace Application.Features.Blacklists.Commands.Create;

public class CreateBlacklistCommandValidator : AbstractValidator<CreateBlacklistCommand>
{
    public CreateBlacklistCommandValidator()
    {
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
    }
}
