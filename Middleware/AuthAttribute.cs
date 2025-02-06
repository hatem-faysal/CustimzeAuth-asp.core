﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustimzeAuth.Middleware;

public class AuthAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.Session.GetString("User");
        if (string.IsNullOrEmpty(user))
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}
