using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReminderBLL
    {
        ReminderDAO dao = new ReminderDAO();
        public bool AddReminder(ReminderDTO model)
        {
            Reminder reminder = new Reminder();
            reminder.TaskID = model.TaskID;
            reminder.CategoryID = model.CategoryID;
            reminder.UserID = UserStatic.UserID;
            reminder.DateAdded = DateTime.Now;
            reminder.NotificationMethod = model.NotificationMethod;
            reminder.ReminderDateTime = model.ReminderDate;

            reminder.ReminderMessage = model.ReminderMessage;
            reminder.ReminderStatusDesc = model.ReminderStatus;
            reminder.WaitType = model.WaitType;
            reminder.WaitPeriod = model.WaitPeriod;

            int ReminderID = dao.AddReminder(reminder);
            LogDAO.AddLog(General.ProcessType.AddReminder, General.ProcessName.AddReminder, ReminderID);
            return true;
        }

        public List<ReminderDTO> GetReminderList()
        {
            return dao.GetReminderList();
        }
    }
}
