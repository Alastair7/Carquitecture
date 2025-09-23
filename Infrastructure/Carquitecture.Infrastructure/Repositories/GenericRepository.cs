using Carquitecture.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken) => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _context.Set<T>().ToListAsync(cancellationToken);

    public async Task<T?> GetByIdAsync(int Id, CancellationToken cancellationToken) => await _context.Set<T>().FindAsync(Id, cancellationToken);
}
