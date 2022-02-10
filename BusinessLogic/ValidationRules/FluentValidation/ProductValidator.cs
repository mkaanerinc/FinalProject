using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p => p.ProductName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(p => p.UnitPrice)
                .NotEmpty()
                .GreaterThan(0)
                .GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            RuleFor(p => p.ProductName)
                .Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
