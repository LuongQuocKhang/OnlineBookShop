using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineBookShop.Core.Lib
{
    public class Auth
    {
        public UserLogin GetUserByUserName(string username)
        {
            using (var db = new DBContext())
            {
                var user = db.AdminAccounts.FirstOrDefault(x => x.AdminName == username);
                return new UserLogin(user);
            }
        }
        public bool Login(string UserName , string Password)
        {
            using (var db = new DBContext())
            {
                var user = db.AdminAccounts.FirstOrDefault(x => x.AdminName == UserName && x.AdminPassword == Password);
                return user != null;
            }
        }
        public UserLogin GetCurrentUser()
        {
            if (HttpContext.Current.Session[Constants.USER_SESSION] == null)
            {
                throw new Exception("User is not defined");
            }
            return (UserLogin)HttpContext.Current.Session[Constants.USER_SESSION];
        }
    }
}
