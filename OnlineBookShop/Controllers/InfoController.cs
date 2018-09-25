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
               
                if ( book != null )
                {
                    ViewBag.Book = book;
                    ViewBag.SameAuthorBook = db.Books.ToArray().Where(x => x.Author.ToLower().Trim() == book.Author.ToLower().Trim() 
                                                                      && x.BookId != book.BookId
                                                                      && x.isDeleted == false).ToList();
                }           
            }
            return View();
        }
    }
}