﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Data;
using TechShop.ViewModel;
using TechShop.Models;
using TechShop.Helper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;


namespace TechShop.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<User>(model); // map model sang kieu User bang automapper
                    customer.RandomKey = MyUtil.GenerateRandomKey();

                    // mã hóa mật khấu => MD5
                    customer.Password = model.Password.ToMd5Hash(customer.RandomKey);


                    _db.Add(customer);
                    _db.SaveChanges();

                    return RedirectToAction("Login", "User");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                }
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Model Error: {error}");
                }
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                //Kiem tra tai khoan
                var customer = _db.User.SingleOrDefault(customer => customer.Email == model.Email);
                if (customer == null)
                {
                    ModelState.AddModelError("Error", "Sai thông tin đăng nhập");
                }
                else
                {
                    if (customer.Password != model.Password.ToMd5Hash(customer.RandomKey))
                    {
                        ModelState.AddModelError("Error", "Sai thông tin đăng nhập");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, customer.Email),
                            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString())
                        };

                        var claimIdentity = new ClaimsIdentity(claims, "login");// danh tính người dùng qua 1 tập hợp các claim được liên kết với quá trình đăng nhập
                        var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                        await HttpContext.SignInAsync(claimsPrincipal);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return Redirect("/Customer/Home/Index");
                        }
                    }
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Model Error: {error}");
                }
                return View(model);
            }
            return View();
        }
    }
}
