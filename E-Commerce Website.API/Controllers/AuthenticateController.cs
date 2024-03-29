﻿
using System.Collections.Immutable;

namespace E_Commerce_Website.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserLogin _userLogin;
        private readonly IConfiguration _configuration;

        private readonly JwtService _jwtService;

        public AuthenticateController(IUserLogin userLogin, JwtService jwtService, IConfiguration configuration)
        {
            _userLogin = userLogin;
            _configuration = configuration;
            _jwtService = jwtService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var user = await _userLogin.FindUserByEmailAsync(model.Username);


            if (user != null && user.Password == model.Password)
            {


                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };


                return Ok(_jwtService.GenerateToken(authClaims));
            }
            return Unauthorized();
        }

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



    }
}


