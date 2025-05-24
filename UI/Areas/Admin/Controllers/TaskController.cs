using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class TaskController : BaseController
    {
        TaskBLL bll = new TaskBLL();
        // GET: Admin/Task

        public ActionResult AddTask()
        {

            var model = new TaskDTO();
             model.Categories = CategoryBLL.getCategoriesForDropdown();

            return View(model);

        }
        [HttpPost]
        public ActionResult AddTask(TaskDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddTask(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    model = new TaskDTO();
                    model.Categories = CategoryBLL.getCategoriesForDropdown();
                    ModelState.Clear();
                    model.Categories = CategoryBLL.getCategoriesForDropdown();

                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
                    model.Categories = CategoryBLL.getCategoriesForDropdown();
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
                model.Categories = CategoryBLL.getCategoriesForDropdown();
            }


            return View(model);

        }

        public ActionResult TaskList()
        {
            List<TaskDTO> dtolist = new List<TaskDTO>();
            dtolist = bll.GetTaskList();
            return View(dtolist);
        }

        public ActionResult UpdateTask(int ID)
        {
            TaskDTO model = new TaskDTO();
            model = bll.GetTaskDataWithID(ID);
            model.Categories = CategoryBLL.getCategoriesForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateTask(TaskDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateTask(model))
                {
                    ViewBag.ProccessState = General.Messages.UpdateSuccess;
                }
                else
                {
                    ViewBag.ProccessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProccessState = General.Messages.EmptyArea;
            }
            model.Categories = CategoryBLL.getCategoriesForDropdown();
            return View(model);
        }


    }
}