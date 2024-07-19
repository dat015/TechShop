using Microsoft.AspNetCore.Mvc;

namespace TechShop.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
