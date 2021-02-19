using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.LastName).MinimumLength(2);
            RuleFor(p => p.Email).MinimumLength(2);
            RuleFor(p => p.Password).MinimumLength(2);
            RuleFor(p => p.Email).Must(Contain).WithMessage("Email not appropriate format");
        }

        private bool Contain(string arg)
        {
            return arg.Contains("@");
        }
    }
}
