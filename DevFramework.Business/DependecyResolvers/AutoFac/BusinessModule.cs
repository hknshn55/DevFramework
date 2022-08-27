using Autofac;
using DevFramework.Business.Abstract;
using DevFramework.Business.Concrete.Managers;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFrameworkCore;
using DevFramework.DataAccess.Abstract;
using DevFramework.DataAccess.Concrete.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Business.DependecyResolvers.AutoFac
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductDal>().As<IProductDal>().SingleInstance();
            base.Load(builder);
        }
    }
}
