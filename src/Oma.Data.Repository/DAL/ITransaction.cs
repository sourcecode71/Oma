namespace Oma.Data.Repository.DAL
{
    public interface ITransaction :IDisposable
    {
        void Commit();
        void Rollback();
    }
}
