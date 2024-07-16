using Microsoft.AspNetCore.Mvc;

namespace TechShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
