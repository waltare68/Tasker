using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        [Required(ErrorMessage = "Please Add a title")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string TaskStatus { get; set; }
        public string Attachments { get; set; }
        [Required(ErrorMessage = "Please add  a due date")]
        public DateTime DueDate { get; set; }
        public String PriorityDescription { get; set; }
        public int PriorityID { get; set; }
        //public List<System.Web.Mvc.SelectListItem> Categories { get; set; }
        //public List<SelectListItem> PriorityList { get; set; }

    }
}
