using TTSHOP.Data.Infrastructure;
using TTSHOP.Model.Models;

namespace TTSHOP.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    { }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}