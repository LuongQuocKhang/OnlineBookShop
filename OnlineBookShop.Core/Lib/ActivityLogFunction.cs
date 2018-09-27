using OnlineBookShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Lib
{
    public static class ActivityLogFunction
    {
        public static void WriteActivity(string Action)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var UserId = (new Auth()).GetCurrentUser().UserId;
                    ActivityLog log = new ActivityLog();
                    log.Action = Action;
                    log.UserId = UserId;
                    log.IP = CoreApp.getUserIP();
                    log.UserAgent = CoreApp.getUserAgent();
                    DateTime now = DateTime.Now;
                    log.ActionTime = DateTime.Parse(now.Month + "/" + now.Day + "/" + now.Year);

                    db.ActivityLogs.Add(log);
                    db.SaveChanges();
                }
                catch(Exception e)
                {

                }
            }
        }

    }
}
