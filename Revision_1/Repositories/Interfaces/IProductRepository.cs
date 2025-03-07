namespace Revision_1.Repositories.Interfaces;
using Revision_1.Data;
using Revision_1.Entities;


public interface IProductRepository : IGenericRepository<Product>   
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
}