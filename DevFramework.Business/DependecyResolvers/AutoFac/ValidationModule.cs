using Autofac;
using DevFramework.Business.ValidationRules.FluentValidation;
using DevFramework.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Business.DependecyResolvers.AutoFac
{
    public class ValidationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductValidator>().As <IValidator<Product>>().SingleInstance();
            base.Load(builder);
        }
    }
}
