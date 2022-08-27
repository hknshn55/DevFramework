using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.ComplexType;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
       private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.Id
                             select new ProductDetail
                             {
                                 ProductId = p.Id,
                                 CategoryName = c.Name,
                                 ProductName = p.Name
                             };
                return result.ToList();
            }
        }
    }
}
