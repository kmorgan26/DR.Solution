using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;

public class HardwareSystemInsertVmValidator: AbstractValidator<HardwareSystemInsertVm>
{
    public HardwareSystemInsertVmValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
                .WithMessage("The Hardware System Name is Required")
            .MaximumLength(25)
                .WithMessage("The name of the Hardware System must be 25 characters or less")
            .MinimumLength(3)
                .WithMessage("The name of the Hardware System must be at least 3 characters long");
    }
}
