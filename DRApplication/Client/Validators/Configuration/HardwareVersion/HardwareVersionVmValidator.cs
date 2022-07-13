using DRApplication.Client.ViewModels;
using FluentValidation;

namespace DRApplication.Client.Validators;
/// <summary>
/// The HardwareVersionVm is used on the Insert Form, and converted to 
/// a HardwareVersionInsertVm prior to insert. The HardwareVersionVm is kept in AppState
/// so it can be used for Inserts and Edits as well as Reads.
/// The mapping is a direct 1:1, so no issues
/// </summary>
public class HardwareVersionEditVmValidator: AbstractValidator<HardwareVersionEditVm>
{
    public HardwareVersionEditVmValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
                .WithMessage("The Hardware Version Name is Required")
            .MaximumLength(25)
                .WithMessage("The name of the Hardware Version must be 25 characters or less")
            .MinimumLength(2)
                .WithMessage("The name of the Hardware Version must be at least 2 characters long");

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
