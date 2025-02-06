using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustimzeAuth.Middleware;

    public class NoLoginAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("User");
                Console.WriteLine(user);
            if (!string.IsNullOrEmpty(user))
            {
                Console.WriteLine("222");
                // Redirect logged-in users to the home page
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            
            base.OnActionExecuting(context);
        }
    }
