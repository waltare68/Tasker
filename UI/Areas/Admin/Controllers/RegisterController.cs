using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        UserBLL bll = new UserBLL();
        public ActionResult Index()
        {
            UserDTO model = new UserDTO();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                bll.AddUser(model);
                ViewBag.ProcessState = General.Messages.AddSuccess;
                ModelState.Clear();
                model = new UserDTO();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
                return View(model);
            }

           
        }

                public ActionResult RegisterUser()
        {
            UserDTO model = new UserDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult RegisterUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                bll.AddUser(model);
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