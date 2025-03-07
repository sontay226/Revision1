using Revision_1.Data;
using Revision_1.Data;
using Revision_1.Entities;
using Revision_1.Repositories.Interfaces;
using Revision_1.UnitOfWork;
using System;
namespace Revision_1.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context) { _context = context; }

    public async Task<IEnumerable<T>> GetAllAsync() { return  _context.Set<T>().ToList(); }
    public async Task AddAsync( T entity ) { await _context.Set<T>().AddAsync(entity); }

    public void UpdateByIdAsync(String _id , T entity) {
        var exitstFind = _context.Set<T>().Find(_id);
        if (exitstFind != null) {
            _context.Entry(exitstFind).CurrentValues.SetValues( entity );
            Console.WriteLine("Updated entity succesfully");
        } else {
            Console.WriteLine("Updated entity failed");
        }
    }

    public void DeleteByIdAsync(String _id) {
        var exitstFind = _context.Set<T>().Find(_id);
        if (exitstFind != null) {
            _context.Set<T>().Remove(exitstFind);
            Console.WriteLine("Deleted entity succesfully");
        } else {
            Console.WriteLine("Delete entity failed");
        }
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities) {
        await _context.Set<T>().AddRangeAsync(entities);
        return entities;
    }
}