using E_Commerce_Website.Helpers;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce_Website.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpAPIWrapper _apiwrapper;

        public UserLoginController(IConfiguration configuration, HttpAPIWrapper httpapiwrapper)
        {
            _configuration = configuration;
            _apiwrapper = httpapiwrapper;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var endpoint = Constants.APIEndpoints.Login;
            var content = new LoginAPIModel
            {
                Username = username,
                Password = password,
            };
            var response = await _apiwrapper.PostAsync<TokenResponse, LoginAPIModel>(endpoint, content);
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

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {

                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Login");
            }

        }

        public IActionResult Register()
        {
            return View();
        }
    }
}


