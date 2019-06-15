using System;

namespace TTSHOP.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TTShopDbContext Init();
    }
}