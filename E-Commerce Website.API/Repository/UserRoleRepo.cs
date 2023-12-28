namespace E_Commerce_Website.API.Repository
{
    public class UserRoleRepo : Repository<UserRole>, IUserRole
    {
        private readonly OganiContext _context;
        public UserRoleRepo(OganiContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<int> GetRolesAsync(int userId)
        {
            var userRoles = await _context.UserRoles
              .Where(ur => ur.Userid == userId)
              .ToListAsync();

            // Assuming you want to return the count of roles for the user
            return userRoles.Count;
        }
    }
}
