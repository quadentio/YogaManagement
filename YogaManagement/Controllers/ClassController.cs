using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YogaManagement.Attributes;

namespace YogaManagement.Controllers
{
    [ServiceFilter(typeof(LoggingFilterService))]
    //[Authorize("AdminOnly")]
    public class ClassController : Controller
    {
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
    }
}
