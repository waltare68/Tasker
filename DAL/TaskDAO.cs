using DTO;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class TaskDAO : CSRMDBManager
    {
        public int AddTask(Task tsk)
        {
            try
            {
                db.Tasks.Add(tsk);
                db.SaveChanges();
                return tsk.TaskID;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TaskDTO> GetTaskListData()
        {
            var categoryList = (from task in db.Tasks
                                join category in db.Categories
                                on task.CategoryID equals category.ID
                                where task.UserID == UserStatic.UserID
                                orderby task.CreatedAt
                                select new TaskDTO
                                {
                                    TaskID = task.TaskID,
                                    Title = task.Title,
                                    DueDate = task.DueDate ?? DateTime.Now,
                                    Description = task.Description,
                                    TaskStatus = task.TaskStatus,
                                    PriorityDescription = task.PriorityDescription,
                                    CategoryID = task.CategoryID,
                                    CategoryName = category.CategoryName
                                }).ToList();

            return categoryList;
        }
        public List<Task> GetPendingTasks()
        {
            var today = DateTime.Today;
            return db.Tasks
                     .Where(t => t.TaskStatus != "Completed" && t.DueDate >= today && t.UserID == UserStatic.UserID)
                     .OrderBy(t => t.DueDate)
                     .ToList();
        }

        public List<TaskDTO> GetDashboardTaskListData()
        {
            var taskList = (from task in db.Tasks
                            join category in db.Categories
                            on task.CategoryID equals category.ID
                            where task.UserID == UserStatic.UserID
                            orderby task.CreatedAt
                            select new TaskDTO
                            {
                                TaskID = task.TaskID,
                                Title = task.Title,
                                DueDate = task.DueDate ?? DateTime.Now, 
                                Description = task.Description,
                                TaskStatus = task.TaskStatus,
                                PriorityDescription = task.PriorityDescription,
                                CategoryID = task.CategoryID,
                                CategoryName = category.CategoryName
                            }).ToList();

            return taskList;
        }

        public object getTopTasksList()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<SelectListItem> getTasksForDll()
        {
            var UserID = UserStatic.UserID;
            IEnumerable<SelectListItem> taskList = db.Tasks.Where(x => x.TaskStatus != "Cancelled" && x.TaskStatus != "Completed" && x.DueDate >= DateTime.Now && x.UserID == UserID).OrderByDescending(x => x.CreatedAt).Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = SqlFunctions.StringConvert((double)x.TaskID)
            }).ToList();
            return taskList;
        }

        public object getTaskCategoriesForDll()
        {

            IEnumerable <SelectListItem> categorylist = db.Categories.Where(x => x.UserID == UserStatic.UserID).OrderByDescending(x => x.DateAdded).Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return categorylist;
        }

        public TaskDTO GetTaskDataWithID(int taskID)
        {
            Task tsk = db.Tasks.First(x => x.TaskID == taskID);
            TaskDTO dto = new TaskDTO();
            dto.TaskID = tsk.TaskID;
            dto.Title = tsk.Title;
            dto.CategoryID = tsk.CategoryID;
            dto.Description = tsk.Description;
            dto.DueDate = (DateTime)tsk.DueDate;
            dto.TaskStatus = tsk.TaskStatus;
            dto.PriorityDescription = tsk.PriorityDescription;

            return dto;
        }

        public void UpdateTask(TaskDTO model)
        {
            try
            {
                Task tsk = db.Tasks.First(x => x.TaskID == model.TaskID);
                tsk.Title = model.Title;
                tsk.Description = model.Description;
                tsk.TaskStatus = model.TaskStatus;
                tsk.UpdatedAt = DateTime.Now;
                tsk.CategoryID = model.CategoryID;//2;//TODO
                tsk.PriorityDescription = model.PriorityDescription;
                tsk.PriorityID = 2;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public decimal GetTodaysTasksValue(DateTime today)
        {
            try
            {
                return db.Tasks.Where(x => x.UserID == UserStatic.UserID).Count(t => t.DueDate == today);
            }
            catch (Exception ex)
            {
               // throw new Exception("Error retrieving today's tasks: " + ex.Message, ex);
                return 0;
            }
        }

        public int GetCompletedTasksCount()
        {
            try
            {
                return db.Tasks.Where(x => x.UserID == UserStatic.UserID).Count(t => t.TaskStatus =="completed");
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
