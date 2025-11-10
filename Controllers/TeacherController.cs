using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
