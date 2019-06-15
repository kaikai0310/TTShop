using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TTSHOP.Data.Infrastructure;
using TTSHOP.Data.Repositories;
using TTSHOP.Model.Models;

namespace TTSHOP.UnitTest.ReposioryTest
{
    [TestClass]
    public class PostCategoryReppositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll() {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count); 
        }


        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "Test-Category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();


            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}