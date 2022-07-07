using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;

public class HardwareConfigInsertVmValidator : AbstractValidator<HardwareConfigInsertVm>
{
    public HardwareConfigInsertVmValidator()
    {
        RuleFor(m => m.Name)
            .NotNull()
            .NotEmpty()
                .WithMessage("The Hardware Configuration Name is required")
            .MaximumLength(50)
                .WithMessage("The Hardware Configuration Name cannot be longer than 50 characters in length")
            .MinimumLength(2)
                .WithMessage("The Hardware Configuration Name cannot be less than 3 characters in length");

        RuleFor(m => m.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Platform");

    }
}
