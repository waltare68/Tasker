using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class UserProfileController : BaseController
    {
        // GET: Admin/UserProfile
        UserBLL bll = new UserBLL();
        public ActionResult UserProfile()
        {
            UserDTO model = new UserDTO();
            model = bll.getLoggedUserDetails();
            return View(model);
        }
        [HttpPost]
        public ActionResult UserProfile(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                bll.UpdateUser(model);
                ViewBag.ProcessState = General.Messages.AddSuccess;
                ModelState.Clear();
                model = new UserDTO();
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

    }
}