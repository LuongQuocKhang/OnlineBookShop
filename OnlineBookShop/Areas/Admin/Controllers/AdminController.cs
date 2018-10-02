using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineBookShop.Core;
using OnlineBookShop.Core.Lib;
using OnlineBookShop.Core.Models;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post()
        {
            if ( ModelState.IsValid )
            {
                string email = "";
                string password = "";
                try
                {
                    email = Request.Form["inputEmail"];
                    password = Request.Form["inputPassword"];

                    Auth admin = new Auth();
                    var result = admin.Login(email, password);
                    if ( result)
                    {
                        var UserSession = admin.GetUserByUserName(email);
                        Session.Add(Constants.ADMIN_SESSION, UserSession);

                        ActivityLogFunction.WriteActivity("Login");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                catch (Exception)
                {

                }
            }         
            return View();
        }

        public ActionResult BookManagement()
        {
            return new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Book" }, { "Action", "Index" } });
        } 
    }
}