using Microsoft.AspNetCore.Mvc;

namespace TechShop.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
