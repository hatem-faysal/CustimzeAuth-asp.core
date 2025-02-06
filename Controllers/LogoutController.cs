using Microsoft.AspNetCore.Mvc;
using CustimzeAuth.Data;

namespace CustimzeAuth.Controllers
{
    public class LogoutController : Controller
    {
        private readonly EcommerceDbContext _context;

        public LogoutController(EcommerceDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Account");
        }
        
    }



}
