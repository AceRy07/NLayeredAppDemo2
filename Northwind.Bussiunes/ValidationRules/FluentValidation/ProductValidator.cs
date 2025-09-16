using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiunes.ValidationRules.FluentValidation
{
    // Hangi model için doğrulama yapacaksak onu belirtiriz. Burada Product için yapıyoruz.
    // AbstractValidator<T> -> Belirtilen tablo için doğrulama yapar.
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Temel kurallar
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            // Geliştirilmiş kurallar 
            // UnitPrice > 0'dan büyük olmak zorunda
            RuleFor(p => p.UnitPrice).GreaterThan(0);

            // UnitInStck Int16 olduğundan hata çıkar.
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);

            // CategoryId 2 ise 10'dan büyük olmak zorunda
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);

            // Bu şekilde olmayan Validationları kendimiz tanımlayabiliriz.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile başlamalı");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
