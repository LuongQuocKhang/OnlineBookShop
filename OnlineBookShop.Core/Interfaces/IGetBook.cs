using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Interfaces
{
    public interface IGetBook
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookByName(string bookname);
        IEnumerable<Book> GetBookByAuthor(string autorname);
    }
}
