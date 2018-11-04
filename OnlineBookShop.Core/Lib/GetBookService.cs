using OnlineBookShop.Core.Interfaces;
using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Lib
{
    public class GetBookService : IGetBook
    {
        public IEnumerable<Book> GetAllBook()
        {
            IEnumerable<Book> list = new List<Book>();
            using (var db = new DBContext())
            {
                list = db.Books.ToList();
            }
            return list;
        }

        public IEnumerable<Book> GetBookByAuthor(string autorname)
        {
            IEnumerable<Book> list = new List<Book>();
            using (var db = new DBContext())
            {
                list = db.Books.ToArray().Where(x => x.Author.ToLower().Trim() == autorname
                                                                      && x.BookId != autorname
                                                                      && x.isDeleted == false).ToList();
            }
            return list;
        }

        public Book GetBookByName(string bookname)
        {
            Book book = new Book();
            using (var db = new DBContext())
            {
                book = db.Books.ToArray().FirstOrDefault(x => x.Name.Equals(bookname));
            }
            return book;
        }
    }
}
