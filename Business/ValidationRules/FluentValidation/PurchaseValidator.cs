﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PurchaseValidator:AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(p => p.PurchaseDate).NotEmpty();
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();

        }
    }
}
