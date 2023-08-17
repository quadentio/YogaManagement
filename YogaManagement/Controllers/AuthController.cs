using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YogaManagement.Attributes;
using YogaManagement.Common;
using YogaManagement.Validator;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    public class AuthController : BaseController
    {
        private readonly IValidator<LoginViewModel> _loginValidator;
        public AuthController(IValidator<LoginViewModel> loginValidator)
        {
            _loginValidator = loginValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            var validateResult = _loginValidator.Validate(login);
            if (!validateResult.IsValid)
            {
                validateResult.AddToModelState(ModelState);
                return View(login);
            }

            // Verify the credential
            if (login.UserName == "admin" && login.Password == "Admin@123")
            {
                // Create security context
                var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim(ClaimTypes.Role, "admin")
                };

                var identity = new ClaimsIdentity(claims, Const.COOKIE_SCHEME);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };

                // Inject security context
                await HttpContext.SignInAsync(Const.COOKIE_SCHEME, claimsPrincipal, authProperties);
            }
            else if (login.UserName == "user" && login.Password == "User@123")
            {
                // Create security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                };

                var identity = new ClaimsIdentity(claims, Const.COOKIE_SCHEME);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };

                // Inject security context
                await HttpContext.SignInAsync(Const.COOKIE_SCHEME, claimsPrincipal, authProperties);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Const.COOKIE_SCHEME);
            // Remove cookie authentication
            return RedirectToAction("Index");
        }
    }
}
