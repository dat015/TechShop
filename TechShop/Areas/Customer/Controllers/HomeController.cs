﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechShop.Models;
using TechShop.ViewModel;
using TechShop.Data;
using Microsoft.EntityFrameworkCore;
using TechShop.Helper;
using Microsoft.AspNetCore.Authorization;

namespace TechShop.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    


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
            List<Role> roles = await _db.Roles.ToListAsync();
            foreach(var item in roles)
            {
                Console.WriteLine(item.roleName);
            }
            var viewModel = new HomeViewModel(list_cate, list_product);

            return View(viewModel);
        }

        public IActionResult ProductByCategory(int idCate)
        {
            List<Product> list_product = _db.Products.Where(x => x.CategoryId == idCate).OrderBy(x => x.ProductName).ToList();
            return View(list_product);
        }

        public async Task<IActionResult> Product(string sortOrder, int? cateId)
        {
            var products = _db.Products.AsQueryable();

            if (cateId.HasValue)
            {
                products = products.Where(p => p.CategoryId == cateId.Value);
            }

            switch (sortOrder)
            {
                case "priceAsc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "nameAsc":
                    products = products.OrderBy(p => p.ProductName);  
                    break;
                default:
                    products = products.OrderByDescending(p => p.ProductName);  
                    break;
            }

            List<Product> result = await products.ToListAsync();

            Category category = await _db.Categories.FindAsync(cateId);

            return View(new ProductViewModel(result, category));
        }


        public IActionResult ProductDetail(int? id)
        {
            var product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();  
            }
            return View(product);
        }


     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
