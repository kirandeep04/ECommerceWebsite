using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce_Website.API.Repository
{
    public class UserLoginRepo : Repository<UserLogin>, IUserLogin
    {
        private readonly Ogani1Context _context;

        public UserLoginRepo(Ogani1Context context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLogin> FindUserByEmailAsync(string email)
        {
            var user = await _context.UserLogins
                .Include(ur => ur.UserRoles)
                .ThenInclude(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Name == email);

            return user;
        }
    }
}
