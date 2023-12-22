namespace E_Commerce_Website.API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<T?> FindByAsync(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task<T?> GetById(int id);
        Task Update(int id, T entity);
        Task<int> Delete(int id);
        Task<int> SaveChangesAsync();

    }
}
