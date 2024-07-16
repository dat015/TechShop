using Microsoft.AspNetCore.Mvc;

namespace TechShop.Areas.Admin.Controllers
{
    public class PaymentMethodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
