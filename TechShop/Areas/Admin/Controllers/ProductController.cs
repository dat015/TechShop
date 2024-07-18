using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechShop.Data;
using TechShop.Models;
using TechShop.Repository;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Products.OrderBy(p => p.ProductId).Include(p => p.CategoryOfProducts).ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Model có một vài thứ đang bị lỗi";
                List<string> errors = new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var err in value.Errors)
                    {
                        errors.Add(err.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            else
            {
                // tra ve True la da ton tai san pham co ten
                /*bool isProductName = _db.Products.Any(p => p.ProductName.Equals(product.ProductName));
                if (isProductName)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(product);
                }
                else
                {
                    
                }*/
                if (product.ImageUpLoad != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                    string imgName = Guid.NewGuid().ToString() + "_" + product.ImageUpLoad.FileName;
                    string filePath = Path.Combine(uploadDir, imgName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpLoad.CopyToAsync(fs);
                    fs.Close();
                    product.Img = imgName;
                }
                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["success"] = "Tạo thành công sản phẩm";
                return RedirectToAction("Index");
            }
        }
    }
}
