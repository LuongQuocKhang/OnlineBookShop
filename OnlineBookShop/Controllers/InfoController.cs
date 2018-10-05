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
    [RoutePrefix("Info")]
    public class InfoController : Controller
    {
        // GET: Info
        [HttpGet]
        [ActionName("BookDetails")]
        [Route("BookDetails/{bookname}")]
        public ActionResult Index(string bookname)
        {
            using (var db = new DBContext())
            {
                var name = bookname.Replace('-', ' ');
                var book = db.Books.ToArray().FirstOrDefault(x => x.Name.Equals(name));

                if (book != null)
                {
                    ViewBag.Book = book;
                    ViewBag.SameAuthorBook = db.Books.ToArray().Where(x => x.Author.ToLower().Trim() == book.Author.ToLower().Trim()
                                                                      && x.BookId != book.BookId
                                                                      && x.isDeleted == false).ToList();
                }
            }
            return View();
        }
        [HttpPost]
        [ActionName("AddToCart")]
        [Route("AddToCart")]
        public ActionResult AddToCart()
        {
            string bookid = ""; int quantity = 0;
            bookid = Request.Form["bookid"];
            quantity = int.Parse(Request.Form["Quantity"]);

            using (var db = new DBContext())
            {
                var user = (UserLogin)Session[Constants.USER_SESSION];
                var cart = db.Cart.FirstOrDefault(x => x.UserName == user.UserName);
                if (user != null)
                {
                    var product = db.CartDetail.FirstOrDefault(x => x.BookId == bookid);
                    CartDetails details;
                    if ( product != null )
                    {
                        details = product;
                        details.Quantity += quantity;
                    }
                    else
                    {
                        details = new CartDetails();
                        details.BookId = bookid;
                        details.CartId = cart.CartId;
                        details.Quantity = quantity;
                        details.Voucher = "";
                        db.CartDetail.Add(details);
                    }
                    var listdetail = db.CartDetail.Where(x => x.CartId == cart.CartId).ToList();
                    double totalprice = 0;
                    foreach (var item in listdetail)
                    {
                        var price = db.Books.FirstOrDefault(x => x.BookId == bookid).Price;
                        totalprice += item.Quantity * price.Value;
                    }
                    cart.TotalPrice = totalprice;
                    db.SaveChanges();
                    
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
    }
}