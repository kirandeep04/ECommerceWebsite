namespace E_Commerce_Website.API.Repository
{
    public class UserRoleRepo : Repository<UserRole>, IUserRole
    {
        private readonly OganiContext _context;
        public UserRoleRepo(OganiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetRolesAsync(string username)
        {
            var userRoles = await _context.UserRoles
                .Where(ur => ur.User.Username == username) // Assuming User is the navigation property to the User table
                .ToListAsync();

            return userRoles;
        }
    }
}
