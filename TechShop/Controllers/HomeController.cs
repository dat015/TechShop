using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechShop.Models;
using TechShop.Data;
using Microsoft.EntityFrameworkCore;

namespace TechShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> list_cate = await _db.Categories.ToListAsync();
            List<Product> list_product = await _db.Products.ToListAsync();
            var viewModel = new HomeViewModel(list_cate, list_product);

            return View(viewModel);
        }

        public IActionResult ProductByCategory(int idCate)
        {
            List<Product> list_product = _db.Products.Where(x => x.CategoryId == idCate).OrderBy(x => x.ProductName).ToList();
            return View(list_product);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
