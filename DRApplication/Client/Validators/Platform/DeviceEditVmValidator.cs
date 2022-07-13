using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;
public class DeviceEditVmValidator: AbstractValidator<DeviceEditVm>
{
    public DeviceEditVmValidator()
    {
        RuleFor(x => x.Device)
        .NotEmpty()
            .WithMessage("The Device Name is required. We gotta call them something!")
        .MaximumLength(20)
            .WithMessage("The Device Name cannot be more than 20 characters in length")
        .MinimumLength(4)
            .WithMessage("The Device Name cannot be less than 4 characters in length");

        RuleFor(x => x.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Platform");

        RuleFor(x => x.IsActive)
            .NotNull();
    }
}
