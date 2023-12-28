using E_Commerce_Website.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Commerce_Website.API.Repository
{
    public class UserLoginRepo : Repository<UserLogin>, IUserLogin
    {
        private readonly OganiContext _context;
        public UserLoginRepo(OganiContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<bool> CheckPasswordAsync(string username, string? password)
        {
            var user = await _context.UserLogins
                .FirstOrDefaultAsync(u => u.Username == username);

            // Check if the user exists and the password matches
            if (user != null && user.Password == password)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public virtual async Task<string> FindByNameAsync(string username)
        {
            var user = await _context.UserLogins.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                return "Username found";
            }
            else
            {
                return "Username not found";
            }
        }

    
    }
}
