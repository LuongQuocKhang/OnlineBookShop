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
                if (user != null)
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
        public ActionResult ChangeQuantity()
        {
            string bookid = "", action = "";
            try { bookid = Request.Form["bookid"]; } catch (Exception e) { }
            try { action = Request.Form["action"]; } catch (Exception e) { }

            using (var db = new DBContext())
            {
                var User = (UserLogin)Session[Constants.USER_SESSION];
                int cartid = db.Cart.FirstOrDefault(x => x.UserName == User.UserName).CartId;
                CartDetails book = db.CartDetail.FirstOrDefault(x => x.BookId == bookid && x.CartId == cartid);
                if (action == "Increase")
                {
                    book.Quantity += 1;
                }
                else if (action == "Decrease")
                {
                    book.Quantity -= 1;
                }
                db.SaveChanges();
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCart(string bookid)
        {
            using (var db = new DBContext())
            {
                var User = (UserLogin)Session[Constants.USER_SESSION];
                int cartid = db.Cart.FirstOrDefault(x => x.UserName == User.UserName).CartId;
                CartDetails book = db.CartDetail.FirstOrDefault(x => x.BookId == bookid && x.CartId == cartid);
                if (book != null)
                {
                    db.CartDetail.Remove(book);
                    db.SaveChanges();
                }
            }
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }
    }
}