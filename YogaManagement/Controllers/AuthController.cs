using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YogaManagement.Attributes;
using YogaManagement.Common;
using YogaManagement.Services;
using YogaManagement.Validator;
using YogaManagement.ViewModel;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    public class AuthController : BaseController
    {
        private readonly IValidator<LoginViewModel> _loginValidator;
        private readonly IValidator<RegisterViewModel> _registerValidator;
        private readonly IAuthService _authService;
        public AuthController(IValidator<LoginViewModel> loginValidator, IValidator<RegisterViewModel> registerValidator, IAuthService authService)
        {
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            // 1. Validate user login information
            // 2. Verify user login information
            // 3. Create security context (cookie authentication)
            // 4. Signin with security context

            // Input Validation
            var result = _loginValidator.Validate(login);
            if (result != null && !result.IsValid)
            {
                result.AddToModelState(ModelState);
                login.Errors = new List<ErrorViewModel>();
                result.AddToErrorViewModel(login);
                return View(login);
            }

            // Verify user and create identity (BL Validation)
            var verifiedUser = _authService.VerifyUserLoginInformation(login);
            if (verifiedUser == null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                //ModelState.GetErrorMessages(login);
                return View(login);
            }

            // Create security context
            var identity = _authService.CreateSecurityContext(verifiedUser);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            // Inject security context
            await HttpContext.SignInAsync(Const.COOKIE_SCHEME, claimsPrincipal, authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            // Validate register information
            var result = _registerValidator.Validate(register);
            if (result != null && !result.IsValid)
            {
                result.AddToModelState(ModelState);
                return View(register);
            }
            if (!_authService.CheckDuplicateUserInformation(register))
            {
                ModelState.AddModelError(nameof(register.UserName), "Username is registered, please choose other username");
                return View(register);
            }

            // Register information
            if (!_authService.RegisterUserInformation(register))
            {
                ModelState.AddModelError("", "Register user information fail, please try again later!!");
                return View(register);
            }

            // Save session information

            return RedirectToAction("RegisterSuccess");
        }

        //[HttpGet]
        //public IActionResult RegisterSuccess()
        //{
        //    // Check session information before loading page
        //}

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Const.COOKIE_SCHEME);
            // Remove cookie authentication
            return RedirectToAction("Index");
        }
    }
}
