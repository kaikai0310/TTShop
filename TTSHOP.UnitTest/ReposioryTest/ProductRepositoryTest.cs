using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TTSHOP.Data.Infrastructure;
using TTSHOP.Data.Repositories;
using TTSHOP.Model.Models;

namespace TTSHOP.UnitTest.ReposioryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IDbFactory dbFactory;
        private IProductRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Product_Repository_Create()
        {
            Product product = new Product();
            product.Name = "Product 1";
            product.Alias = "product-1";
            product.CategoryID = 1;
            product.Price = 350000;
            product.OriginalPrice = 300000;
            product.Quantity = 20;
            product.Warranty = 12;
            product.Status = true;

            var result = objRepository.Add(product);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void Product_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count);
        }
    }
}