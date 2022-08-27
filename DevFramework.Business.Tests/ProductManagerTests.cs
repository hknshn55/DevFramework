using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationExeption))]
        [TestMethod]
        public void Product_validation_Check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
