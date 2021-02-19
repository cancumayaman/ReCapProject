using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.ReturnDate).Must(ControlNull).WithMessage("Now, Our another customer has this car. We cannot rent this car at the moment");
        }

        private bool ControlNull(DateTime? arg)
        {
            return arg.GetValueOrDefault() != null;
        }
    }
}
