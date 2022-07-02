using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;

public class MaintenanceIssueInsertVmValidator : AbstractValidator<MaintenanceIssueInsertVm>
{
    public MaintenanceIssueInsertVmValidator()
    {
        RuleFor(m => m.Description)
            .NotNull()
            .NotEmpty()
                .WithMessage("The Description cannot be empty")
            .MinimumLength(3)
                .WithMessage("The Decription must be longer than 3 characters");

        RuleFor(m => m.ActionTaken)
            .NotNull()
            .NotEmpty()
                .WithMessage("The Action Taken cannot be empty")
            .MinimumLength(3)
                .WithMessage("The Action Taken must be longer than 3 characters. Don't be lazy.")
            .MaximumLength(50)
                .WithMessage("The Action Taken cannot be longer than 50 characters in length");

        RuleFor(m => m.IssueDate)
            .NotNull()
            .NotEmpty()
                .WithMessage("You must enter an Issue Date")
            .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("You cannot enter a future date for an Issue Date");

        RuleFor(m => m.Pid)
            .NotNull()
            .NotEmpty()
                .WithMessage("Enter a PID. If you don't know the PID...just wing it.")
            .MinimumLength(3)
                .WithMessage("PID Must contain at least 3 characters")
            .MaximumLength(10)
                .WithMessage("PID Must be 10 characters or less");

        RuleFor(x => x.DeviceId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Device");

        RuleFor(x => x.CorrectiveActionId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Corrective Action");

    }
}
