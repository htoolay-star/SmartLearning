using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
