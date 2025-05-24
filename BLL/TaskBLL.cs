using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class TaskBLL
    {
        TaskDAO dao = new TaskDAO();
        public bool AddTask(TaskDTO model)
        {
            DAL.Task tsk = new DAL.Task();
            tsk.Title = model.Title;
            tsk.Description = model.Description;
            tsk.Category = "";
            tsk.CategoryID = 2;
            tsk.CreatedAt = DateTime.Now;
            tsk.DueDate = model.DueDate;
            tsk.PriorityDescription = model.PriorityDescription;
            tsk.PriorityID = 1;
            tsk.TaskStatus = model.TaskStatus;
            tsk.UserID = UserStatic.UserID;

            int ID = dao.AddTask(tsk);
            LogDAO.AddLog(General.ProcessType.AddTask, General.ProcessName.AddTask, ID);


            return true;
        }

        public static IEnumerable<SelectListItem> getTasksForDropdown()
        {
            return TaskDAO.getTasksForDll();
        }

        public List<TaskDTO> GetTaskList()
        {
            List<TaskDTO> dtolist = new List<TaskDTO>();
            dtolist = dao.GetTaskListData();
            return dtolist;
        }

        public TaskDTO GetTaskDataWithID(int taskID)
        {
            TaskDTO taskdto = new TaskDTO();
            taskdto = dao.GetTaskDataWithID(taskID);
            return taskdto;
        }

        public bool UpdateTask(TaskDTO model)
        {
            dao.UpdateTask(model);
            LogDAO.AddLog(General.ProcessType.UpdateTask, General.ProcessName.UpdateTask, model.TaskID);
            return true;
        }

        public List<TaskDTO> GetDashboardTaskList()
        {
            List<TaskDTO> dtolist = new List<TaskDTO>();
            dtolist = dao.GetTaskListData();
            return dtolist;
        }

        
    }
}
