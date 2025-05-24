using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogBLL
    {
        public static void AddLog(string ProcessType, String ProcessName, int ProcessID)
        {
            LogDAO.AddLog(ProcessType, ProcessName, ProcessID);
        }
    }
}
