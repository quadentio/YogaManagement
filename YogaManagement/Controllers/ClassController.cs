using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Attributes;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    [Authorize("AdminOnly")]
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
