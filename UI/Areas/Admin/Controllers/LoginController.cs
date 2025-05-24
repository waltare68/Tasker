using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        UserBLL userbll = new UserBLL();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = userbll.GetUserWithUserNameAndPassword(model);
                if (user.ID != 0)
                {
                    UserStatic.UserID = user.ID;
                    UserStatic.IsAdmin = user.IsAdmin;
                    UserStatic.Namesurname = user.FirstName;
                    UserStatic.AvatarUrl = user.AvatarUrl;
                    UserStatic.FirstName = user.FirstName;
                    UserStatic.LastName = user.LastName;
                    LogBLL.AddLog(General.ProcessType.Login, General.ProcessName.Login, 1);

                    return RedirectToAction("DashboardDetails", "Dashboard");
                }

                return View(model);
            }
            else
            {
                return View(model);
            }

        }
    }
}
