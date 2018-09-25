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
    }
}