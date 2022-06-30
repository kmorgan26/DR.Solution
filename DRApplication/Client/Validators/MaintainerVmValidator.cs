using DRApplication.Client.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Validators
{
    public class MaintainerVmValidator : AbstractValidator<MaintainerEditVm>
    {
        public MaintainerVmValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("The Maintainer Name is Required")
                .MaximumLength(25)
                    .WithMessage("The name of the Maintainer must be 25 characters of less")
                .MinimumLength(3)
                    .WithMessage("The name of the Maintainer must be more than 3 characters long");
               
        }
    }
}
