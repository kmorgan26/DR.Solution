using DRApplication.Client.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Validators
{
    public class MaintainerEditVmValidator : AbstractValidator<MaintainerEditVm>
    {
        public MaintainerEditVmValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("The Maintainer Name is Required")
                .MaximumLength(25)
                    .WithMessage("The name of the Maintainer must be 25 characters or less")
                .MinimumLength(3)
                    .WithMessage("The name of the Maintainer must be at least 3 characters long");
        }
    }
}
