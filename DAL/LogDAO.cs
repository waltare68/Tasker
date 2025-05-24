using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class LogDAO : CSRMDBManager
    {
        public static void AddLog(string ProcessType, string ProcessName, int ProcessID)
        {
            Log_T log = new Log_T();
            log.UserID = UserStatic.UserID;
            log.ProcessType = ProcessType;
            log.ID = ProcessID;
            log.ProcessTypeCategory = ProcessName;
            log.AccessTime = DateTime.Now;
            log.IPAddress = HttpContext.Current.Request.UserHostAddress;
            log.DeviceInfo = HttpContext.Current.Request.UserAgent;
            db.Log_T.Add(log);
            db.SaveChanges();
        }
    }
}
