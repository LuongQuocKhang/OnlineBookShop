using OnlineBookShop.Core;
using OnlineBookShop.Core.Lib;
using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineBookShop.Controllers
{
    [RoutePrefix("Cart")]
    public class CartController : Controller
    {
        // GET: Cart
        [Route("Load")]
        public ActionResult Cart()
        {
            using (var db = new DBContext())
            {
                var user = (UserLogin)Session[Constants.USER_SESSION];
                if ( user != null )
                {
                    Cart cart = db.Cart.FirstOrDefault(x => x.UserName == user.UserName);
                    int cartid = cart.CartId;
                    var cartdetail = db.CartDetail.Where(x => x.CartId == cartid).ToList();
                    ViewBag.CartDetails = cartdetail;

                    List<Book> listbook = new List<Book>();
                    foreach (var item in cartdetail)
                    {
                        var book = db.Books.FirstOrDefault(x => x.BookId == item.BookId);
                        listbook.Add(book);
                    }
                    ViewBag.BookList = listbook;
                    return View();
                }
                else
                {
                    return new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "User" }, { "Action", "Login" } });
                }
            }
        }
    }
}