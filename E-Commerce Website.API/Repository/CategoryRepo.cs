namespace E_Commerce_Website.API.Repository
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo

    {
        private readonly Ogani1Context _context;
        private readonly IMemoryCache _cache;
        private readonly CacheManager<Category> _cacheManager;



        public CategoryRepo(Ogani1Context context, IMemoryCache cache, CacheManager<Category> cacheManager) : base(context)
        {
            _context = context;
            _cache = cache;
            _cacheManager = cacheManager;

        }
        //public override async Task<IQueryable<Category>> Get()
        //{
        //    var cachedCategory = _cacheManager.Get(Constants.cacheKeys.categorykey);
        //    if (cachedCategory != null)
        //    {
        //        return cachedCategory.AsQueryable();
        //    }
        //    var entity = _context.Categories.ToList();
        //    _cacheManager.Set(Constants.cacheKeys.categorykey, entity);
        //    return entity.AsQueryable();
        //}
        //public override async Task<Category?> GetById(int id)
        //{
        //    var CachedEntity = _cacheManager.Get(Constants.cacheKeys.categorykey);
        //    var Entityitem = CachedEntity.FirstOrDefault(g => g.Id == id);
        //    if (CachedEntity != null)
        //    {
        //        return Entityitem;
        //    }
        //    var entity = _context.Categories.AsNoTracking().FirstOrDefault(e => e.Id == id);
        //    if (entity != null)
        //    {
        //        CachedEntity ??= new List<Category>();
        //        CachedEntity.Add(entity);
        //        _cacheManager.Set(Constants.cacheKeys.categorykey, CachedEntity);
        //    }
        //    return entity;
        //}

        //public override async Task<int> Delete(int id)
        //{
        //    var entity = await GetById(id);
        //    if (entity == null)
        //    {
        //        return 0;
        //    }
        //    _context.Categories.Remove(entity);
        //    var cachedResult = _cacheManager.Get(Constants.cacheKeys.categorykey);
        //    if (cachedResult != null)
        //    {
        //        cachedResult.Remove(entity);
        //        _cacheManager.Set(Constants.cacheKeys.categorykey, cachedResult);
        //    }
        //    return await _context.SaveChangesAsync();
        //}

        //public override async Task Update(int id, Category entity)
        //{
        //    // Find the entity in the database context asynchronously
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category != null)
        //    {                // Update the entity properties with the new values
        //        _context.Entry(category).CurrentValues.SetValues(entity);

        //        foreach (var property in _context.Entry(category).Properties)
        //        {
        //            var currentValues = property.OriginalValue;
        //            var proposedValues = property.CurrentValue;
        //            if (proposedValues == null)
        //            {
        //                property.IsModified = false;
        //            }
        //            else if (!proposedValues.Equals(currentValues))
        //            {
        //                property.IsModified = true;
        //            }
        //        }
        //        await _context.SaveChangesAsync();
        //        var cachedCategory = _cacheManager.Get(Constants.cacheKeys.categorykey);
        //        if (cachedCategory != null)
        //        {
        //            //FindIndex similar to FirstorDefault
        //            var index = cachedCategory.FindIndex(e => e.Id == id);
        //            if (index != -1)

        //            {
        //                cachedCategory[index] = category;
        //                _cacheManager.Set(Constants.cacheKeys.categorykey, cachedCategory);
        //            }
        //        }
        //    }
        //}
        //public override async Task Add(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    _context.SaveChangesAsync();

        //    var cachedCategory = _cacheManager.Get(Constants.cacheKeys.categorykey) ?? new List<Category>(); 
        //    cachedCategory.Add(category);
        //    _cacheManager.Set(Constants.cacheKeys.categorykey, cachedCategory);
        //}
        //public override async Task<Category?> FindByAsync(Expression<Func<Category, bool>> predicate)
        //{
        //    var cachedResult = _cacheManager.Get(Constants.cacheKeys.categorykey);
        //    var cacheEntity = cachedResult.FirstOrDefault(predicate.Compile());
        //    if (cacheEntity != null)
        //    {
        //        return cacheEntity;
        //    }

        //    var result = await _context.Set<Category>().AsNoTracking().FirstOrDefaultAsync(predicate) ?? default(Category);

        //    if (result != null)
        //    {
        //        cachedResult ??= new List<Category>();
        //        cachedResult.Add(result);
        //        _cacheManager.Set(Constants.cacheKeys.categorykey, cachedResult);
        //    }

        //    return result;
        //}


    }
}



