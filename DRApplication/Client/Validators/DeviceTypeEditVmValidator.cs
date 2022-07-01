using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;
public class DeviceTypeEditVmValidator : AbstractValidator<DeviceTypeEditVm>
{
    public DeviceTypeEditVmValidator()
    {
        RuleFor(x => x.Platform)
            .NotEmpty()
                .WithMessage("The Platform Name is required. How else would we identify them?")
            .MaximumLength(20)
                .WithMessage("The Platform Name cannot be more than 20 characters in length")
            .MinimumLength(5)
                .WithMessage("The Platform Name cannot be less than 5 characters in length");

        RuleFor(x => x.MaintainerId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Maintainer");
    }
}