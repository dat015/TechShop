using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechShop.Helper;
using TechShop.Data;
using TechShop.Models;
using TechShop.ViewModel;
using Microsoft.EntityFrameworkCore;



namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<OrderVM> GetOrder()
        {
            var orders = await _db.Orders.ToListAsync();
            return new OrderVM()
            {
                orders = orders
            };
        }

        public async Task<IActionResult> Index()
        {
            var orderVM = await GetOrder();
            return View(orderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int OrderId)
        {
            var order = await _db.Orders.Where(o => o.OrderId == OrderId).FirstOrDefaultAsync();
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return RedirectToAction("Index");
        }



    }
}
