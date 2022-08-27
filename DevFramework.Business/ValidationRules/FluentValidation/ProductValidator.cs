using DevFramework.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(2,50);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(50).When(x=>x.CategoryId ==1); //Kategori id = 1 olduğunda unitPrice >= 50 olmalıdır.
            //RuleFor(x => x.Name).Must(StarWithH);
        }
        private bool StarWithH(string arg)
        {
            return arg.StartsWith("H"); //Gelen deger H ilemi başlıyor?
        }
    }
}
