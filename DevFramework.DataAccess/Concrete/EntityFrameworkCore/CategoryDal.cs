using DevFramework.Core.DataAccess.EntityFrameworkCore;
using DevFramework.DataAccess.Abstract;
using DevFramework.DataAccess.Concrete.EntityFrameworkCore.Context;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFrameworkCore
{
    public class CategoryDal:EntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(DevFrameworkContext context) : base(context)
        {

        }
    }
}
