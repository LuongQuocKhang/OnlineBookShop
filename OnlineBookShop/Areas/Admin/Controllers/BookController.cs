using OnlineBookShop.Core.Lib;
using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        // GET: Admin/Book
        public ActionResult Index()
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
                return RedirectToAction("Index");
            }
            catch (Exception e)
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
                return RedirectToAction("Index");
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

            try { bookid = Request.Form["BookId"]; } catch (Exception) { }
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
                bool NewBook = false;
                if (book == null)
                {
                    book = new Book();
                    NewBook = true;
                }
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
                if (NewBook == true)
                {
                    db.Books.Add(book);
                    ActivityLogFunction.WriteActivity("Add book");
                }
                else
                {
                    ActivityLogFunction.WriteActivity("Edit book");
                }
                db.SaveChanges();
            }
            Session["submit_message"] =
                        "<p class='font-green-sharp' style='font-size: 20px;color: #009614!important;font-weight: bold;'>Cập nhật thông tin sách thành công</p>";
            return RedirectToAction("Update", new { bookid = bookid.Trim() });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public ActionResult Add_Post()
        {
            string bookid = "", Name = "", SKU = "", Link = "", Company = "",
                Author = "", PublishDay = "", Publisher = "", CoverType = "",
                status = "", Size = "", Description = "", Catagory = "";
            int? PageNum = 0, Quantity = 0;
            double? Price = 0;

            try { bookid = Request.Form["BookId"]; } catch (Exception) { }
            try { Name = Request.Form["Name"]; } catch (Exception) { }
            try { SKU = Request.Form["SKU"]; } catch (Exception) { }
            try { Company = Request.Form["Company"]; } catch (Exception) { }
            try { Author = Request.Form["Author"]; } catch (Exception) { }
            try { Publisher = Request.Form["Publisher"]; } catch (Exception) { }
            try { status = Request.Form["status"]; } catch (Exception) { }
            try { Size = Request.Form["Size"]; } catch (Exception) { }
            try { Description = Request.Form["Description"]; } catch (Exception) { }
            try { Catagory = Request.Form["Catagory"]; } catch (Exception) { }
            try { Link = Request.Form["Link"]; } catch (Exception) { }
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

            string filename = Request.Form["Image"];

            using (var db = new DBContext())
            {
                Book book = new Book();
                book.BookId = bookid;
                book.Name = Name;
                book.SKU = SKU;
                book.Link = Link;
                book.Image = filename;
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
                db.Books.Add(book);
                ActivityLogFunction.WriteActivity("Add book");
                db.SaveChanges();
            }

            
            string src = Request.Form["src"];

            UploadFileToServerBase64(filename, src);

            Session["submit_message"] =
                        "<p class='font-green-sharp' style='font-size: 20px;color: #009614!important;font-weight: bold;'> Thêm sách thành công</p>";
            return RedirectToAction("Index");
        }
        public bool UploadFileToServerBase64(string imageUrl , string src)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    // Make this directory whatever makes sense for your project.
                    var root = Server.MapPath(string.Format("~/Content/BookImage/"));
                    DirectoryInfo DirInfo = new DirectoryInfo(root);
                    foreach (var File in DirInfo.GetFiles())
                    {
                        if (File.Name.ToUpper().Equals(imageUrl.ToUpper()))
                        {
                            var filename = File.Name;
                            File.Delete();
                        }
                    }
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(src));
                    System.Drawing.Bitmap imageSave = new System.Drawing.Bitmap(ms);
                    var name = imageUrl.Replace('-', ' ');
                    imageSave.Save(root + name);
                }
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        
    }
}