namespace Ellinor.Erp.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
