namespace TTSHOP.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}