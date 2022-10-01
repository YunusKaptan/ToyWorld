using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerName).MinimumLength(3);
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.PostAddress).NotEmpty();
        } 
    }
}
