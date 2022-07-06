using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;

public class HardwareConfigEditVmValidator : AbstractValidator<HardwareConfigEditVm>
{
    public HardwareConfigEditVmValidator()
    {
        RuleFor(x => x.Name).NotNull()
            .NotEmpty()
                .WithMessage("Hardware Configuration Name is required. I shouldn't have to be explaining this part of this. Get it together")
            .MaximumLength(50)
                .WithMessage("Hardware Configuration Name cannot be more than 50 characters in length")
            .MinimumLength(2)
                .WithMessage("Hardware Configuration Name cannot be less than 3 characters in length");

        RuleFor(m => m.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Platform");

    }
}
