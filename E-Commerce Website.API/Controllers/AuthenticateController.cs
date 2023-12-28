//namespace E_Commerce_Website.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticateController : ControllerBase
//    {
//        private readonly IUserLogin _userLogin;
//        private readonly IConfiguration _configuration;
//        private readonly IUserRole _userRole;
//        private readonly JwtService _jwtService;

//        public AuthenticateController(IUserLogin userLogin, IUserRole userRole, JwtService jwtService, IConfiguration configuration)
//        {
//            _userLogin = userLogin;
//            _configuration = configuration;
//            _userRole = userRole;
//            _jwtService = jwtService;
//        }
//        [HttpPost]
//        [Route("Login")]
//        public async Task<IActionResult> Login(LoginModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = await _userLogin.FindByNameAsync(model.Username);
//                if (user != null && (await _userLogin.CheckPasswordAsync(user, model.Password)))
//                {
//                    var claims = new[]
//{
//                     new Claim(JwtRegisteredClaimNames.Sub,model.Username),


//                      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//                };
//                    return Ok(_jwtService.GenerateToken(claims));
//                }
//            }
//            return Unauthorized();

//        }
//}

using E_Commerce_Website.API;

namespace Online_Shopping_Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;
        private readonly IUserLogin _userLogin;
        private readonly IUserRole _userRoles;

        public AuthenticateController(JwtService jwtService, IUserLogin userLogin, IUserRole userRoles, IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtService = jwtService;
            _userLogin = userLogin;
            _userRoles = userRoles;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userLogin.FindByNameAsync(model.Username);
            if (user != null && (await _userLogin.CheckPasswordAsync(user, model.Password)))
            {
                var userRoles = await _userRoles.GetRolesAsync(user);
                var authClaims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Name, model.Username),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                return Ok(_jwtService.GenerateToken(authClaims));
            }

            return Unauthorized();
        }
    }
}
        
    
