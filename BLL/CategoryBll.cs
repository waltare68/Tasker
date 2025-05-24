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
    public class CategoryBLL
    {
        CategoryDAO dao = new CategoryDAO();
        public bool AddCategory(CategoryDTO model)
        {
            Category category = new Category();
            category.CategoryName = model.CategoryName;
            category.Description = model.CategoryDescription;
            category.UserID = UserStatic.UserID;
            category.DateAdded = DateTime.Now;
            int CategoryID = dao.AddCategory(category);
            LogDAO.AddLog(General.ProcessType.AddCategory, General.ProcessName.AddCategory, CategoryID);
            
            return true;
        }
       
        public static object getCategoriesForDDL()
        {
            throw new NotImplementedException();
        }

        //public static List<SelectListItem> GetCategoriesForDropdown()
        //{
        //    return CategoryDAO.GetCategoriesForDropDown();
        //}

        public List<CategoryDTO> GetCategoryData()
        {

            List<CategoryDTO> dtolist = new List<CategoryDTO>();
            dtolist = dao.GetCategoryData();
            return dtolist;
        }
        public static IEnumerable<SelectListItem> getCategoriesForDropdown()
        {
            return CategoryDAO.getTaskCategoriesForDll();
        }

        public CategoryDTO GetCategoryDataWithID(int ID)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO = dao.GetCategoryWithID(ID);
            return categoryDTO;
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model);
            LogDAO.AddLog(General.ProcessType.UpdateCategory, General.ProcessName.UpdateCategory, model.ID);
            return true;
        }
    }
}
