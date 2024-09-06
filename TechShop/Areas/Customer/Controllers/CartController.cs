using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechShop.ViewModel;
using TechShop.Models;
using TechShop.Helper;
using TechShop.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TechShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]


    public class CartController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        private int? userId
        {
            get
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdString, out int UserId))
                {
                    Console.WriteLine(" chuyen doi duoc id");

                    return UserId;
                }
                Console.WriteLine("Khong chuyen doi duoc id");
                return null;
            }
        }




        public CartVM CartVM
        {
            get
            {
                var cartItems = _db.ShoppingCarts
                    .Include(p => p.Product)
                    .Where(p => p.UserId == userId)
                    .ToList();

                var total = cartItems.Sum(item => item.count * item.Product.Price);

                return new CartVM
                {
                    ListCart = cartItems,
                    Total = total
                };
            }
        }





        [HttpGet]
        public IActionResult Index()
        {
            foreach( var item in CartVM.ListCart)
            {
                Console.WriteLine(item.ProductId);
            }
             return View(CartVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var cart = CartVM;
            var item = cart.ListCart.FirstOrDefault(p => p.ProductId == id);//ktra xem da co san pham nay trong gio hang chua
            if (item == null) {
                var product = _db.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    TempData["Message"] = "Product not found";
                    return NotFound();
                }

                item = new ShoppingCart
                {
                    ProductId = id,
                    UserId = (int)userId,
                    count = quantity,
                    Product = product
                };
                _db.ShoppingCarts.Add(item);
            }
            else
            {
                TempData["Message"] = $"Sản phẩm đã có trong giỏ hàng";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
