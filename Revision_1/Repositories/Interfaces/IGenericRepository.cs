using System.Collections;

namespace Revision_1.Repositories.Interfaces;
using System.Linq.Expressions;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>>  getAllAsync();
    public Task addAsync(T entity);
    public void updateByIdAsync( String _id , T entity);
    public void deleteByIdAsync( String _id );
    public Task<IEnumerable<T>> addRangeAsync(IEnumerable<T> entities);
}