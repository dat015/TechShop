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
using TechShop.Utility;


namespace TechShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]


    public class CartController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly ApplicationDb1Context _db1;




        public CartController(ApplicationDbContext db, ApplicationDb1Context db1)
        {
            _db = db;
            _db1 = db1;
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


        public async Task<CartVM> GetCartVMAsync()
        {
            var cartController = await _db.ShoppingCarts
                         .Where(c => c.UserId == userId)
                         .FirstOrDefaultAsync();

            var cartItems = (cartController != null)
                ? await _db.CartDetails.Include(cd => cd.product) // Sử dụng Include để lấy thông tin product
                                      .Where(c => c.CartId == cartController.Id)
                                      .ToListAsync()
                : new List<CartDetail>();

            var provincesItem = await _db1.provinces.ToListAsync();

            var total = cartItems.Sum(item => item.quantity * item.price);

            var payments = _db.PaymentMethods.ToList();

            return new CartVM
            {
                ListCart = cartItems,
                listProvices = provincesItem,
                Total = total,
                cart = cartController,
                paymentMethods = payments

            };
        }


        public Order order;




        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var cartVM = await GetCartVMAsync();


            if (cartVM.cart == null)
            {
                var newCart = new ShoppingCart()
                {
                    UserId = (int)userId
                };
                cartVM.cart = newCart;

                _db.ShoppingCarts.Add(newCart);
                await _db.SaveChangesAsync();

                return View(cartVM);
            }
            else
            {
                return View(cartVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var cartVM = await GetCartVMAsync();
            var item = cartVM.ListCart.FirstOrDefault(p => p.productId == id);//ktra xem da co san pham nay trong gio hang chua
            if (item == null)
            {
                var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null)
                {
                    TempData["Message"] = "Product not found";
                    return NotFound();
                }

                item = new CartDetail()
                {
                    CartId = cartVM.cart.Id,
                    productId = id,
                    quantity = quantity,
                    price = product.Price,
                    product = product
                };
                _db.CartDetails.Add(item);

            }
            else
            {
                item.quantity += quantity;
            }
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var cartItem = await _db.ShoppingCarts.FirstOrDefaultAsync(p => p.Id == id);
                if (cartItem != null)
                {
                    _db.ShoppingCarts.Remove(cartItem);
                    await _db.SaveChangesAsync();

                    TempData["Message"] = "Xóa sản phẩm thành công";
                    Console.WriteLine("Xóa thành công");
                }
                else
                {
                    TempData["Message"] = "Sản phẩm không tồn tại";
                    Console.WriteLine("Sản phẩm không tồn tại");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var cartItem = await _db.CartDetails.FirstOrDefaultAsync(c => c.productId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.quantity = quantity;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        [HttpGet("GetDistrictsByProvice")]
        public async Task<JsonResult> GetDistrictsByProvice(string provinceId)
        {
            var district = await _db1.districts.Where(d => d.province_code == provinceId).ToListAsync();
            foreach (var item in district)
            {
                Console.Write(item.code);
            }
            return Json(district);
        }

        [HttpGet("GetWardsByDistrict")]
        public async Task<JsonResult> GetWardsByDistrict(string districtId)
        {
            Console.WriteLine(districtId);
            var wards = await _db1.wards.Where(w => w.district_code == districtId).ToListAsync();
            return Json(wards);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int PaymentId, string proviceName, string districtName, string wardName, string houseAddress, string name, string phone, string note)
        {
            Console.WriteLine($"Payment ID: {PaymentId}");
            Console.WriteLine($"Tỉnh/Thành phố: {proviceName}");
            Console.WriteLine($"Quận/Huyện: {districtName}");
            Console.WriteLine($"Phường/Xã: {wardName}");
            Console.WriteLine($"Địa chỉ: {houseAddress}");
            Console.WriteLine($"Tên: {name}");
            Console.WriteLine($"Số điện thoại: {phone}");
            Console.WriteLine($"Ghi chú: {note}");
            try
            {
                if (ModelState.IsValid)
                {
                 
                  
                    var cartVM = await GetCartVMAsync();
                    Order order = new Order
                    {
                        phoneNumber = phone,
                        address = houseAddress,
                        provice = proviceName,
                        distrcit = districtName,
                        Name = name,
                        ward = wardName,
                        PaymentMethodId = PaymentId,
                        PaymentDate = DateTime.Now,
                        UserId = (int)userId,
                        user = await _db.User.Where(u => u.Id == userId).FirstOrDefaultAsync(),
                        StatusPayment = SD.PaymentStatusPending,
                        StatusShipping = SD.StatusPending,
                        Note = note,
                        OrderDate = DateTime.Now,
                        TotalAmount = cartVM.Total
                    };
                    Console.WriteLine(order.Name);
                    await _db.Orders.AddAsync(order);
                    await _db.SaveChangesAsync();

                    
                    var detailsCart = await _db.CartDetails.Where(p => p.CartId == cartVM.cart.Id).ToListAsync();
                    List<OrderDetail> detailsOrder = new List<OrderDetail>();
                    foreach (var item in detailsCart)
                    {
                        OrderDetail orderDetail = new OrderDetail()
                        {
                            ProductId = item.productId,
                            product = item.product,
                            Quantity = item.quantity,
                            UnitPrice = item.price * item.quantity,
                            OrderId = order.OrderId,
                            order = order
                        };

                        detailsOrder.Add(orderDetail);
                    }

                    await _db.DetailsOrders.AddRangeAsync(detailsOrder);
                    await _db.SaveChangesAsync();

                    DeleteShoppingCart(cartVM.cart, order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }

            return View("Success");


        }
        public async void DeleteShoppingCart(ShoppingCart cart, Order Order)
        {
            if (Order == null)
            {
                return;
            }
            var cartDeatails = _db.CartDetails.Where(p => p.CartId == cart.Id).ToList();
            _db.CartDetails.RemoveRange(cartDeatails);
            await _db.SaveChangesAsync();
            _db.ShoppingCarts.Remove(cart);
            await _db.SaveChangesAsync();

        }


    }
}
