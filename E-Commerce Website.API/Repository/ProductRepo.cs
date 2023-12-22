namespace E_Commerce_Website.API.Repository
{
    public class ProductRepo : Repository<Product>, IProduct
    {
        private readonly OganiContext _context;
        public ProductRepo(OganiContext context) : base(context)
        {
            _context = context;
        }
    }
}
