using CustimzeAuth.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace CustimzeAuth.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
