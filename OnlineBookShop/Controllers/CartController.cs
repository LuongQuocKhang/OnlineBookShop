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
                    if (cart != null)
                    {
                        int cartid = cart.CartId;
                        ViewBag.CartDetails = db.CartDetail.Where(x => x.CartId == cartid).ToList();
                    }
                    else
                    {
                        cart = new Cart();
                        cart.UserName = user.UserName;
                        cart.TotalPrice = 0;
                        db.Cart.Add(cart);
                        db.SaveChanges();
                    }
                }
                else
                {
                    
                }
            }
            return View();
        }
    }
}