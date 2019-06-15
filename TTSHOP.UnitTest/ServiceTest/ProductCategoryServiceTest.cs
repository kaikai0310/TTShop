using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TTSHOP.Data.Infrastructure;
using TTSHOP.Data.Repositories;
using TTSHOP.Model.Models;
using TTSHOP.Service;

namespace TTSHOP.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductCategoryServiceTest
    {
        private Mock<IProductCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductCategoryService _categoryService;
        private List<ProductCategory> listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new ProductCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            listCategory = new List<ProductCategory>(){
                new ProductCategory(){ ID = 1,Name= "DM1",Status=true},
                new ProductCategory(){ ID = 2,Name= "DM2",Status=true},
                new ProductCategory(){ ID = 3,Name= "DM3",Status=true},
            };
        }

        [TestMethod]
        public void ProductCategory_Service_Create()
        {
            ProductCategory productCategory = new ProductCategory();
            int id = 1;
            productCategory.Name = "Test ProductCate";
            productCategory.Alias = "test-productcate";
            productCategory.Status = true;

            _mockRepository.Setup(m => m.Add(productCategory)).Returns((ProductCategory p)=>
            {
                p.ID = 1;
                return p;
            });

            var result = _categoryService.Add(productCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void ProductCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(listCategory);

            //call action
            var result = _categoryService.GetAll() as List<ProductCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}