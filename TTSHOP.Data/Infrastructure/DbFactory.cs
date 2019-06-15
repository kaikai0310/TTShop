namespace TTSHOP.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TTShopDbContext dbContext;

        public TTShopDbContext Init()
        {
            return dbContext ?? (dbContext = new TTShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}