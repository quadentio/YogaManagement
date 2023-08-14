using Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Attributes;
using YogaManagement.Validator;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    public class AuthController : BaseController
    {
        private readonly IValidator<User> _userValidator;
        public AuthController(IValidator<User> userValidator)
        {
            _userValidator = userValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Index(User login)
        {
            var validateResult = _userValidator.Validate(login);
            if (!validateResult.IsValid)
            {
                validateResult.AddToModelState(ModelState);
                //return View(login);
            }

            return View(login);
        }

        [HttpPost]
        public IActionResult Register()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Remove cookie authentication
            return RedirectToAction("Index");
        }
    }
}
