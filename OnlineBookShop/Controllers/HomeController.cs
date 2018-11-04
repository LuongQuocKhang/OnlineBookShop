using OnlineBookShop.Core;
using OnlineBookShop.Core.Interfaces;
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
        private readonly IGetBook _BookService;
        public HomeController(IGetBook BookService)
        {
            this._BookService = BookService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.BookList = _BookService.GetAllBook();
            return View();
        }
    }
}