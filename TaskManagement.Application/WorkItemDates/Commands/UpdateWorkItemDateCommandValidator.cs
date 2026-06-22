using FluentValidation;

namespace TaskManagement.Application.WorkItemDates.Commands;

public class UpdateWorkItemDateCommandValidator : AbstractValidator<UpdateWorkItemDateCommand>
{
    public UpdateWorkItemDateCommandValidator()
    {
        RuleFor(x => x.WorkItemId).NotEmpty();

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("StartDate must be provided.");

        RuleFor(x => x.CloseDate)
            .Must((command, closeDate) =>
                !closeDate.HasValue ||
                closeDate.Value >= command.StartDate)
            .WithMessage("CloseDate cannot be before StartDate.");
    }
}
