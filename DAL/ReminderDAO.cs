using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReminderDAO : CSRMDBManager
    {
        public int AddReminder(Reminder reminder)
        {
            db.Reminders.Add(reminder);
            db.SaveChanges();
            return reminder.ReminderID;
        }

        public List<ReminderDTO> GetReminderList()
        {
            var reminderList = (from r in db.Reminders
                                join c in db.Categories on r.CategoryID equals c.ID
                                join t in db.Tasks on r.TaskID equals t.TaskID
                                where r.UserID == UserStatic.UserID
                                select new
                                {
                                    ID = r.ReminderID,
                                    TaskTitle = t.Title,
                                    CategoryName = c.CategoryName,
                                    WaitType = r.WaitType,
                                    waitPeriod = r.WaitPeriod,
                                    ReminderMessage = r.ReminderMessage,
                                    DateAdded = r.DateAdded
                                }
                                ).OrderByDescending(x => x.DateAdded).ToList();

            List<ReminderDTO> dtoList = new List<ReminderDTO>();
            foreach (var item in reminderList)
            {
                ReminderDTO dto = new ReminderDTO();
                dto.TaskName = item.TaskTitle;
                dto.CategoryName = item.CategoryName;
                dto.WaitType = item.WaitType;
                dto.ReminderID = item.ID;
                dto.WaitPeriod = item.waitPeriod;
                dto.ReminderMessage = item.ReminderMessage;
                dto.DateAdded = (DateTime)item.DateAdded;
                dtoList.Add(dto);

            }
            return dtoList;

        }

        public int GetTodaysRemindersCount(DateTime today)
        {
            try
            {
                return db.Reminders.Where(x => x.UserID == UserStatic.UserID)
                    .Count(r => r.ReminderDateTime.Date == today);
            }
            catch (Exception ex)
            {
                //throw new Exception("Error retrieving today's reminders: " + ex.Message, ex);TODO Log Exceptions
                return 0;
            }
        }
        public decimal GetDeliveredReminders()
        {
            try
            {
                return db.Reminders.Where(x => x.UserID == UserStatic.UserID)
                    .Count(r => r.ReminderStatusDesc == "complete");
            }
            catch (Exception ex)
            {
                //throw new Exception("Error retrieving delivered reminders: " + ex.Message, ex);
                return 0;
            }
        }
    }
}
