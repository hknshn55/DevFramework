
using DevFramework.Core.DataAccess.EntityFrameworkCore;
using DevFramework.DataAccess.Abstract;
using DevFramework.DataAccess.Concrete.EntityFrameworkCore.Context;
using DevFramework.Entities.ComplexType;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFrameworkCore
{
    public class ProductDal : EntityRepositoryBase<Product>, IProductDal
    {
        private readonly DevFrameworkContext _context;
        public ProductDal(DevFrameworkContext context):base(context)
        {
            _context = context;
        }

        public List<ProductDetail> GetProductDetails()
        {
                var result = from p in _context.Products
                             join c in _context.Categories
                             on p.Id equals c.Id
                             select new ProductDetail
                             {
                                 CategoryName = c.Name,
                                 ProductId = p.Id,
                                 ProductName = p.Name
                             };
                return result.ToList();
        }
    }
}
