namespace Carquitecture.Application.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetByIdAsync(int Id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
}
