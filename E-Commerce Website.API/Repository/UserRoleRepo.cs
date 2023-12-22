namespace E_Commerce_Website.API.Repository
{
    public class UserRoleRepo : Repository<UserRole>, IUserRole
    {
        private readonly OganiContext _context;
        public UserRoleRepo(OganiContext context) : base(context)
        {
            _context = context;
        }
    }
}
