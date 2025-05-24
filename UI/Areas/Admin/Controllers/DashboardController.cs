using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        DashboardService ds = new DashboardService();
        public ActionResult DashboardDetails()
        {
            var model = new DashboardViewDTO()
            {
                DashletData = ds.getDashletData(),
                TaskList = ds.GetDashboardTaskList(),
                ScheduleList = ds.GetPendingSchedules()
            };

            return View(model);
        }
    }
}