using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                        Session.Add(Constants.USER_SESSION, UserSession);
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
            using (var db = new DBContext())
            {
                ViewBag.BookList = db.Books.ToList();
            }
            return View();
        }
        public ActionResult Delete(string bookid)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var book = db.Books.FirstOrDefault(x => x.BookId == bookid);
                    book.isDeleted = true;
                    db.SaveChanges();
                }
                return RedirectToAction("BookManagement");
            }
            catch(Exception e)
            {

            }
            return View();
        }
        public ActionResult Restore(string bookid)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var book = db.Books.FirstOrDefault(x => x.BookId == bookid);
                    book.isDeleted = false;
                    db.SaveChanges();
                }
                return RedirectToAction("BookManagement");
            }
            catch (Exception e)
            {

            }
            return View();
        }
    }
}