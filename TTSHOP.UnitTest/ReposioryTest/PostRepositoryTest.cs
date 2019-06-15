using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TTSHOP.Data.Infrastructure;
using TTSHOP.Data.Repositories;
using TTSHOP.Model.Models;

namespace TTSHOP.UnitTest.ReposioryTest
{
    [TestClass]
    public class PostRepositoryTest
    {
        private IDbFactory dbFactory;
        private IUnitOfWork unitOfWork;
        private IPostRepository objRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            unitOfWork = new UnitOfWork(dbFactory);
            objRepository = new PostRepository(dbFactory);
        }

        [TestMethod]
        public void Post_Repository_Create() {
            Post post = new Post();
            post.Name = "Post 1";
            post.Alias = "post-1";
            post.CategoryID = 1;
            post.HomeFlat = true;
            post.HotFlat = true;
            post.Status = true;

            var result = objRepository.Add(post);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void Post_Repository_GetAll() {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count);
        }
    }
}