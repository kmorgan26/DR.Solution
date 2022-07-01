using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;
/// <summary>
/// This is a validator used for Edits.
/// There are no rules for the Maintainer Property because it won't be used in 
/// database edits. The EditVms will be mapped prior to database operations
/// </summary>
public class DeviceTypeVmValidator : AbstractValidator<DeviceTypeVm>
{
    public DeviceTypeVmValidator()
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
