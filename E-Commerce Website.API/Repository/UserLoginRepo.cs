namespace E_Commerce_Website.API.Repository
{
    public class UserLoginRepo : Repository<UserLogin>, IUserLogin
    {
        private readonly OganiContext _context;
        public UserLoginRepo(OganiContext context) : base(context)
        {
            _context = context;
        }
    }
}
