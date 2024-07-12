using Microsoft.AspNetCore.Mvc;

namespace TechShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
