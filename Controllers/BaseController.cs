using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMCVdemo.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string action = filterContext.ActionDescriptor.ActionName.ToLower();
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();

            bool isLoginAllowed =
                (controller == "home" && (action == "login" || action == "authorize")) ||
                (controller == "logins" && action == "create");

            if (!isLoginAllowed && Session["UserName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { controller = "Home", action = "Login" }
                    )
                );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}