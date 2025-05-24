using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class UserPreferenceController : BaseController
    {
        // GET: Admin/UserPreference
        public ActionResult AddUserPreference()
        {
            UserPreferenceDTO model = new UserPreferenceDTO();
            return View(model);
        }
    }
}