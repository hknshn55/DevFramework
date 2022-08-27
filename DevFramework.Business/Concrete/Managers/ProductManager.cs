using DevFramework.Business.Abstract;
using DevFramework.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.Postsharp.CacheAspect;
using DevFramework.Core.Aspects.Postsharp.TransactionAspect;
using DevFramework.Core.Aspects.Postsharp.ValidationAspect;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;
using System.Collections.Generic;
using System.Transactions;

namespace DevFramework.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(/*"patter",*/typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return product;
        }

        [CacheAspect(typeof(MemoryCacheManager)/*istenirse dakika verilebilir => ,120*/)]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x=>x.Id == id);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product p1, Product p2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                    _productDal.Add(p1);
                   //Kurallar
                   
                    _productDal.Update(p2);
            }
            
        }
    }
}
