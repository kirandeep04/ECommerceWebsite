namespace E_Commerce_Website.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OganiContext _context;

        public Repository(OganiContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<int> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return 0;
            }
            _context.Set<T>().Remove(entity);
            return await SaveChangesAsync();
        }

        public virtual async Task<T?> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate) ?? default(T);
        }

        public virtual async Task<IQueryable<T>> Get()
        {
            var user = _context.Set<T>().AsQueryable();
            return await Task.FromResult(user);
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id") == id);

            //return await _context.Set<T>().FindAsync(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual async Task Update(int id, T entity)
        {
            var user = await _context.Set<T>().FindAsync(id);
            if (user != null)
            {
                // Update the values of the existing entity with the values from the new entity
                _context.Entry(user).CurrentValues.SetValues(entity);
                foreach (var properties in _context.Entry(user).Properties)
                {
                    var CurrentValues = properties.OriginalValue;
                    var ProposedValues = properties.CurrentValue;
                    if (CurrentValues == null)
                    {
                        properties.IsModified = false;
                    }
                    else if (ProposedValues != CurrentValues)
                    {
                        properties.IsModified = true;
                    }
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
