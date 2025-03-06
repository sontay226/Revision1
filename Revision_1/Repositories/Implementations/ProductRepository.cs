using System.Collections;
using Microsoft.EntityFrameworkCore;
using Revision_1.Entities;
using Revision_1.Repositories.Interfaces;
using Revision_1.Data;
namespace Revision_1.Repositories.Implementations;

public class ProductRepository :  GenericRepository<Product> , IProductRepository 
{
    public ProductRepository( ApplicationDbContext context) : base(context) {}

    public async Task<IEnumerable<Product>> getProductsByPriceAsync(decimal minPrice) {
        return await _context.Set<Product>().Where(p => p.getPrice() >= minPrice).ToListAsync();
    }
}