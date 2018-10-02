using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Lib
{
    public class UserLogin
    {
        public UserLogin() { }
        public UserLogin(string username,int id)
        {
            UserName = username;
            UserId = id;
        }
        public UserLogin(AdminAccount account)
        {
            UserName = account.AdminName;
            UserId = account.AdminId;
        }
        public string UserName { get; set; }
        public int UserId { get; set; }

    }
}
