using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class ReminderController : BaseController
    {
        // GET: Admin/Reminder
        ReminderBLL bll = new ReminderBLL();
        public ActionResult AddReminder()
        {
            ReminderDTO model = new ReminderDTO();
            model.Categories = CategoryBLL.getCategoriesForDropdown();
            model.Tasks = TaskBLL.getTasksForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddReminder(ReminderDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddReminder(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;

                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }

            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.Tasks = TaskBLL.getTasksForDropdown();
            model.Categories = CategoryBLL.getCategoriesForDropdown();
            return View(model);
        }

        public ActionResult ReminderList()
        {
            List<ReminderDTO> reminderlist = new List<ReminderDTO>();
            reminderlist = bll.GetReminderList();
            return View(reminderlist);
        }
        public ActionResult UpdateReminder()
        {
            return View();
        }

    }
}