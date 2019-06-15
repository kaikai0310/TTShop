using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TTSHOP.Data.Infrastructure;
using TTSHOP.Data.Repositories;
using TTSHOP.Model.Models;

namespace TTSHOP.UnitTest.ReposioryTest
{
    [TestClass]
    public class ProductCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IProductCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Product_Category_Create()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Product Category";
            productCategory.Alias = "product-category";
            productCategory.Status = true;

            var result = objRepository.Add(productCategory);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void Product_Category_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count);
        }
    }
}