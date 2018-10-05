using OnlineBookShop.Core;
using OnlineBookShop.Core.Lib;
using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineBookShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
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
                        return new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Home" }, { "Action", "Index" } });
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
            return new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Home" }, { "Action", "Index" } });
        }
        [HttpGet]
        [ActionName("Register")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register_Post()
        {
            string FirstName = "", LastName = "", PhoneNumber = "",
                DateOfBirth = "", Email = "", Password = "", CofirmPassword = "";
            string policy = "";

            policy = Request.Form["policy"];
            if (policy == "")
            {
                Session["submit_message"] =
                    "<p class='font-green-sharp danger' style='font-size: 20px;color: #009614!important;font-weight: bold;'>vui lòng đồng ý điều khoảng</p>";
                return RedirectToAction("Register");
            }

            try { FirstName = Request.Form["firstName"]; } catch (Exception) { }
            try { LastName = Request.Form["lastName"]; } catch (Exception) { }
            try { PhoneNumber = Request.Form["Phonenumber"]; } catch (Exception) { }
            try { DateOfBirth = Request.Form["DateOfBirth"]; } catch (Exception) { }
            try { Email = Request.Form["inputEmail"]; } catch (Exception) { }
            try { Password = Request.Form["inputPassword"]; } catch (Exception) { }
            try { CofirmPassword = Request.Form["confirmPassword"]; } catch (Exception) { }
            DateTime time = DateTime.Now;
            try { time = DateTime.ParseExact(DateOfBirth + " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); } catch (Exception) { }
            try
            {           
                if (Password != CofirmPassword)
                {
                    Session["submit_message"] =
                        "<p class='font-green-sharp' style='font-size: 20px;color: #009614!important;font-weight: bold;'>mật khẩu xác nhận không chính xác</p>";
                    return RedirectToAction("Login");
                }
                UserAccount user = new UserAccount();
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.PhoneNumber = PhoneNumber;
                user.DateOfBirth = time;
                user.Email = Email;
                user.Password = Password;

                using (var db = new DBContext())
                {
                    db.UserAcount.Add(user);
                    Cart cart = new Cart();
                    cart.UserName = user.Email;
                    cart.TotalPrice = 0;
                    db.Cart.Add(cart);

                    db.SaveChanges();
                }
                Session["submit_message"] =
                        "<p class='font-green-sharp' style='font-size: 20px;color: #009614!important;font-weight: bold;'>Đăng ký thành công</p>";
                return RedirectToAction("Register");
            }
            catch(Exception)
            {

            }
            return RedirectToAction("Register");
        }
    }
}