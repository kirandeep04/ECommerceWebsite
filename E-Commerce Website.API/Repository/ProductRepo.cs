namespace E_Commerce_Website.API.Repository
{
    public class ProductRepo : Repository<Product>, IProduct
    {
        private readonly Ogani1Context _context;
        public ProductRepo(Ogani1Context context) : base(context)
        {
            _context = context;
        }
    }
}
