using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DashboardService
    {
        TaskDAO taskdao = new TaskDAO();
        ReminderDAO remdao = new ReminderDAO();


        public List<TaskDTO> GetDashboardTaskList()
        {
            List<TaskDTO> dtolist = new List<TaskDTO>();
            dtolist = taskdao.GetTaskListData();
            return dtolist;
        }

        public List<ScheduleDTO> GetPendingSchedules()
        {
            TaskDAO taskDAO = new TaskDAO();

            var pendingTasks = taskDAO.GetPendingTasks();

            return pendingTasks.Select(task => new ScheduleDTO
            {
                Title = task.Title,
                ScheduleDateTime = task.DueDate ?? DateTime.Now,
                IconClass = "relative z-10 text-transparent ni leading-none ni-bell-55 leading-pro bg-gradient-to-tl from-green-600 to-lime-400 bg-clip-text fill-transparent",//"ni-calendar", 
                Description = $"Due on {task.DueDate?.ToString("dd MMM hh:mm tt")}"
            }).ToList();
        }
        public DashletsDTO getDashletData()
        {
            var today = DateTime.Today;
            var todaysTasks = taskdao.GetTodaysTasksValue(today);
            var todaysReminders = remdao.GetTodaysRemindersCount(today);
            var completedTasks = taskdao.GetCompletedTasksCount();
            var deliveredReminders = remdao.GetDeliveredReminders();

            



            var taskChangePercentage = "+55%";
            var reminderChangePercentage = "+3%";
            var completedTaskChangePercentage = "-2%";
            var deliveredReminderChangePercentage = "+5%";

            return new DashletsDTO
            {
                TodaysTasks = todaysTasks,
                TodaysReminders = todaysReminders,
                CompletedTasks = completedTasks,
                DeliveredReminders = deliveredReminders,
                TaskChangePercentage = taskChangePercentage,
                ReminderChangePercentage = reminderChangePercentage,
                CompletedTaskChangePercentage = completedTaskChangePercentage,
                DeliveredReminderChangePercentage = deliveredReminderChangePercentage
            };
        }

        
    }
}
