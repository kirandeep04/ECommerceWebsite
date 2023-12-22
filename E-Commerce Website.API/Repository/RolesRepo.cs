namespace E_Commerce_Website.API.Repository
{
    public class RolesRepo : Repository<Role>, IRoles
    {
        private readonly OganiContext _context;
        public RolesRepo(OganiContext context) : base(context)
        {
            _context = context;
        }
    }
}
