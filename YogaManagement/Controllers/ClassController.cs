using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YogaManagement.Attributes;
using YogaManagement.Validator;
using YogaManagement.ViewModel.Class;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    //[Authorize("AdminOnly")]
    public class ClassController : Controller
    {
        private readonly IValidator<ClassViewModel> _classValidator;
        public ClassController(IValidator<ClassViewModel> classValidator)
        {
            _classValidator = classValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAllClassData()
        {
            // Get all data
            return Json(JsonConvert.SerializeObject(new { success = "true" }));
        }

        [HttpPost]
        public IActionResult RegisterClassData(ClassViewModel request)
        {
            // Validate request
            var validation = _classValidator.Validate(request);
            if (!validation.IsValid)
            {
                request.Errors = new List<ViewModel.ErrorViewModel>();
                validation.AddToErrorViewModel(request);
                return Json(JsonConvert.SerializeObject(request));
            }
            // BL Services

            // Success response
            return Json(JsonConvert.SerializeObject(new { success = "true" }));
        }
    }
}
