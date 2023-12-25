﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using startup.Areas.Admin.Models;
using startup.Models;
using startup.Utilities;

namespace startup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }

        [Route("/register")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(AdminUser user)
        {
            if (user == null) 
            {
                return NotFound();
            }
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);
            Console.WriteLine(user.UserName);

            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null) 
            {
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.AdminUsers.Add(user);
            _context.SaveChanges();

            return Redirect("~/login");
        }
    }
}
