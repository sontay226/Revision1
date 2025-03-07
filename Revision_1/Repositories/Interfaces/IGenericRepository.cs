using System.Collections;

namespace Revision_1.Repositories.Interfaces;
using System.Linq.Expressions;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>>  GetAllAsync();
    public Task AddAsync(T entity);
    public void UpdateByIdAsync( String _id , T entity);
    public void DeleteByIdAsync( String _id );
    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
}