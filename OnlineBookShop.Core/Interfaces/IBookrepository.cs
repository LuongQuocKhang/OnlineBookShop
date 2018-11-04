using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Interfaces
{
    public interface IBookrepository
    {
        int AddBook();
        int DeleteBook();
        int RestoreBook();
        int UpdateBook();
    }
}
