using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ErrorLogRequestValidator : AbstractValidator<ErrorLogRequest>
    {
        public ErrorLogRequestValidator()
        {
            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.StatusCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Enter a valid value")
               .GreaterThan(0).WithMessage("StatusCode must be an integer");
            RuleFor(x => x.ErrorMessage)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Details)
              .NotEmpty().WithMessage("Enter a valid value");
        }
    }
}
