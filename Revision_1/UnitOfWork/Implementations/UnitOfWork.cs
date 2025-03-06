using Revision_1.Data;
using Revision_1.Entities;
using Revision_1.UnitOfWork.Interfaces;
using Revision_1.Repositories;
using Revision_1.Repositories.Implementations;
using Revision_1.Repositories.Interfaces;
using Revision_1.UnitOfWork;
namespace Revision_1.UnitOfWork.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IProductRepository Products { get; private set; }
    public  UnitOfWork(ApplicationDbContext dbContext , IProductRepository productRepository)
    {
        _context = dbContext;
        Products = productRepository;
    }

    public async Task<int> CompleteAsync() {
        return await _context.SaveChangesAsync();
    }

    public void Dispose() {
        _context.Dispose();
    }
}