using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
