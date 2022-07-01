using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;

public class HardwareVersionInsertVmValidator: AbstractValidator<HardwareVersionInsertVm>
{
    public HardwareVersionInsertVmValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
                .WithMessage("The Hardware Version Name is Required")
            .MaximumLength(25)
                .WithMessage("The name of the Hardware Version must be 25 characters or less")
            .MinimumLength(3)
                .WithMessage("The name of the Hardware Version must be at least 3 characters long");

        RuleFor(m => m.VersionDate)
            .NotEmpty()
                .WithMessage("The Version Date is required")
            .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("The Version Date cannot be a future date");

        RuleFor(m => m.HardwareSystemId)
            .NotEmpty()
                .WithMessage("The Hardware System is required")
            .GreaterThan(0)
                .WithMessage("The Hardware System is required");
    }
}
