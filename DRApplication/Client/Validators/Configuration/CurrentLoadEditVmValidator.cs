using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators.Configuration;

public class CurrentLoadEditVmValidator: AbstractValidator<CurrentLoadEditVm>
{
    public CurrentLoadEditVmValidator()
    {
        RuleFor(m => m.DeviceId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Device");

        RuleFor(m => m.LoadId)
            .NotNull()
            .GreaterThan(0)
                .WithMessage("You must select a Load");

    }
}
