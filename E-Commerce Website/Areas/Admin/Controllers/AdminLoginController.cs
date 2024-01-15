using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce_Website.Helpers;

namespace E_Commerce_Website.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminLoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpAPIWrapper _apiWrapper;

        public AdminLoginController(IConfiguration configuration, HttpAPIWrapper apiWrapper)
        {
            _configuration = configuration;
            _apiWrapper = apiWrapper;

        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AdminLogIn()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var endpoint = Constants.APIEndpoints.Login;
            var content = new LoginAPIModel
            {
                Username = username,
                Password = password,
            };
            var response = await _apiWrapper.PostAsync<TokenResponse, LoginAPIModel>(endpoint, content);
            if (response != null)
            {
                var tokenData = response.data;

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenparameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration.GetValue<string>("JWT:Issuer"),
                    ValidAudience = _configuration.GetValue<string>("JWT:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")))
                };
                SecurityToken ValidatedToken;
                var principal = tokenHandler.ValidateToken(tokenData.Token, tokenparameters, out ValidatedToken);

                var adminId = principal.FindFirst(ClaimTypes.Name)?.Value;
                var adminRole = principal.FindFirst(ClaimTypes.Role)?.Value;
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("AdminLogIn");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAPIModel model)
        {
            var endpoint = Constants.APIEndpoints.Register;
            var content = new RegisterAPIModel
            {

                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            };

            var response = await _apiWrapper.PostAsync<TokenResponse, RegisterAPIModel>(endpoint, content);

            if (response != null)
            {
                var tokenData = response.data;


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenparameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration.GetValue<string>("JWT:Issuer"),
                    ValidAudience = _configuration.GetValue<string>("JWT:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")))

                };

                SecurityToken ValidatedToken;
                var principal = tokenHandler.ValidateToken(tokenData.Token, tokenparameters, out ValidatedToken);

                var userId = principal.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = principal.FindFirst(ClaimTypes.Role)?.Value;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Dashboard");
            }


            return RedirectToAction("AdminLogIn");
        }
        public IActionResult SignUp()
        {
            return View();
        }



    }
}
