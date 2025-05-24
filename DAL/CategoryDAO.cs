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
    public class CategoryDAO : CSRMDBManager
    {
        public int AddCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return category.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CategoryDTO> GetCategoryData()
        {
            List<CategoryDTO> categorylist = new List<CategoryDTO>();
            List<Category> list = db.Categories.Where(x => x.UserID == UserStatic.UserID).OrderBy(x => x.DateAdded).ToList();
            foreach (var item in list)
            {
                CategoryDTO dto = new CategoryDTO();
                dto.ID = item.ID;
                dto.CategoryName = item.CategoryName;
                dto.CategoryDescription = item.Description;
                categorylist.Add(dto);
            }
            return categorylist;
        }

        public static IEnumerable<SelectListItem> getTaskCategoriesForDll()
        {

            IEnumerable<SelectListItem> categorylist = db.Categories.Where(x => x.UserID == UserStatic.UserID).OrderByDescending(x => x.DateAdded).Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return categorylist;
        }


        public CategoryDTO GetCategoryWithID(int ID)
        {
            Category category = db.Categories.First(x => x.ID == ID);
            CategoryDTO dto = new CategoryDTO();
            dto.ID = category.ID;
            dto.CategoryName = category.CategoryName;
            dto.CategoryDescription = category.Description;
            return dto;

        }

        public void UpdateCategory(CategoryDTO model)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == model.ID);
                category.CategoryName = model.CategoryName;
                category.Description = model.CategoryDescription;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
