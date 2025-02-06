using Microsoft.AspNetCore.Mvc;
using CustimzeAuth.Models;
using CustimzeAuth.Data;
using System.Security.Cryptography;
using System.Text;
using CustimzeAuth.Middleware;

namespace CustimzeAuth.Controllers
{
    [NoLoginAccess]
    public class AccountController : Controller
    {
        private readonly EcommerceDbContext _context;

        public AccountController(EcommerceDbContext context)
        {
            _context = context;
        }
        [HttpGet("login")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User model)
        {
            string hashedPassword = HashPassword(model.Password);
            var user = _context.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == hashedPassword);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return RedirectToAction("Login");
            }
            HttpContext.Session.SetString("User", user.Name);
            return RedirectToAction("Index", "Home");
        }
        
        
        [HttpGet("register")]

        public IActionResult Register()
        {
            return View();
        }
    
        [HttpPost("register")]
        public IActionResult Register(User model)
        {
            if (_context.Users.Any(u => u.Name == model.Name))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View();
            }
            string hashedPassword = HashPassword(model.Password);
            var user = new User { Name = model.Name, Password = hashedPassword };
            _context.Users.Add(user);
            _context.SaveChanges();
            HttpContext.Session.SetString("User", user.Name);
            return RedirectToAction("Index", "Home");            
        }
        
        
        
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }        
        
    }



}
