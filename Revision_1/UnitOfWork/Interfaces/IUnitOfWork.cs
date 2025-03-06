using Revision_1.Repositories.Interfaces;

namespace Revision_1.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    Task<int> CompleteAsync();
}