namespace E_Commerce_Website.API.Repository
{
    public class RolesRepo : Repository<Role>, IRoles
    {
        private readonly Ogani1Context _context;
        public RolesRepo(Ogani1Context context) : base(context)
        {
            _context = context;
        }
    }
}
