using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
