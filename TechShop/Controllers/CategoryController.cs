using Microsoft.AspNetCore.Mvc;
using TechShop.Data;
using TechShop.Models;

namespace TechShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            List<Category> lstCat = _db.Categories.ToList();
            return View(lstCat);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
