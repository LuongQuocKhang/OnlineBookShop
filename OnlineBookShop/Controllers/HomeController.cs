using OnlineBookShop.Core;
using OnlineBookShop.Core.Lib;
using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using ( var db = new DBContext())
            {
                ViewBag.BookList = db.Books.Where(x =>x.isDeleted == false).ToList();
            }
            return View();
        }
        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post()
        {
            if (ModelState.IsValid)
            {
                string email = "";
                string password = "";
                try
                {
                    email = Request.Form["inputEmail"];
                    password = Request.Form["inputPassword"];

                    Auth user = new Auth();
                    var result = user.Login(email, password);
                    if (result)
                    {
                        var UserSession = user.GetUserByUserName(email);
                        Session.Add(Constants.USER_SESSION, UserSession);

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
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}