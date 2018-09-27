using System;
using System.Collections.Generic;
using System.Globalization;
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
                ActivityLogFunction.WriteActivity("Delete book");
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
                ActivityLogFunction.WriteActivity("Restore book");
                return RedirectToAction("BookManagement");
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update(string bookid)
        {
            using (var db = new DBContext())
            {
                var book = db.Books.FirstOrDefault(x => x.BookId == bookid);
                ViewBag.SelectedBook = book;
            }

            return View();
        }

        [HttpPost]
        [ActionName("Update")]
        public ActionResult Update_Post()
        {
            string bookid = "", Name = "", SKU = "", Company = "",
                 Author = "", PublishDay = "", Publisher = "", CoverType = "",
                 status = "", Size = "", Description = "", Catagory = "";
            int? PageNum = 0, Quantity = 0;
            double? Price = 0;

            try { bookid = Request.Form["BookId"]; } catch (Exception){ }
            try { Name = Request.Form["Name"]; } catch (Exception) { }
            try { SKU = Request.Form["SKU"]; } catch (Exception) { }
            try { Company = Request.Form["Company"]; } catch (Exception) { }
            try { Author = Request.Form["Author"]; } catch (Exception) { }
            try { Publisher = Request.Form["Publisher"]; } catch (Exception) { }
            try { status = Request.Form["status"]; } catch (Exception) { }
            try { Size = Request.Form["Size"]; } catch (Exception) { }
            try { Description = Request.Form["Description"]; } catch (Exception) { }
            try { Catagory = Request.Form["Catagory"]; } catch (Exception) { }
            try { CoverType = Request.Form["CoverType"]; } catch (Exception) { }
            try { PublishDay = Request.Form["PublishDay"]; } catch (Exception) { }

            try { Price = double.Parse(Request.Form["Price"]); } catch (Exception) { }
            try { PageNum = int.Parse(Request.Form["PageNum"]); } catch (Exception) { }
            try { Quantity = int.Parse(Request.Form["Quantity"]); } catch (Exception) { }

            DateTime time = DateTime.Now;
            try
            {
                time = DateTime.ParseExact(PublishDay + " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception e) { }

            using (var db = new DBContext())
            {
                Book book = db.Books.FirstOrDefault(x => x.BookId.Trim() == bookid);
                book.Name = Name;
                book.SKU = SKU;
                book.Company = Company;
                book.Author = Author;
                book.Publisher = Publisher;
                book.PublishDay = time;
                book.CoverType = CoverType;
                book.Price = Price;
                book.PageNum = PageNum;
                book.Quantity = Quantity;
                book.status = status;
                book.Size = Size;
                book.Description = Description;
                book.Catagory = Catagory;
                db.SaveChanges();
                ActivityLogFunction.WriteActivity("Edit book");
            }
            return RedirectToAction("BookManagement");
        }
    }
}