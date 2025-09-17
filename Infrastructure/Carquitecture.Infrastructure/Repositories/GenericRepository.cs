using Carquitecture.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);

    public void Delete(T entity) =>  _dbSet.Remove(entity);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _dbSet.ToListAsync(cancellationToken);

    public async Task<T?> GetByIdAsync(int Id, CancellationToken cancellationToken) => await _dbSet.FindAsync(Id, cancellationToken);

    public void Update(T entity) => _dbSet.Update(entity);
}
