using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        CategoryBLL bll = new CategoryBLL();
        public ActionResult AddCategory()
        {
            CategoryDTO dto = new CategoryDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddCategory(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    
                    ModelState.Clear();
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
            CategoryDTO newModel = new CategoryDTO();
            return View(newModel);
        }

        public ActionResult CategoryList()
        {
            List<CategoryDTO> model = new List<CategoryDTO>();
            model = bll.GetCategoryData();
            return View(model);
        }

        public ActionResult UpdateCategory(int ID)
        {
            CategoryDTO model = new CategoryDTO();
            model = bll.GetCategoryDataWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateCategory(model))
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
            return View(model);
        }
    }
}