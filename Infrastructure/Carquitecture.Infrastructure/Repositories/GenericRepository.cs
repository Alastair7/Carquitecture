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

    public void Update(T entity) 
    {
        _context.Set<T>().Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) 
    {
        var result =  _context
            .Set<T>()
            .AsNoTracking()
            .AsQueryable();

        return await result.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int Id, CancellationToken cancellationToken) 
        => await _context.Set<T>().AsNoTracking()
        .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id, cancellationToken);
}