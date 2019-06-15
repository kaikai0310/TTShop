using TTSHOP.Data.Infrastructure;
using TTSHOP.Model.Models;

namespace TTSHOP.Data.Repositories
{
    public interface ITagRepository :IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}