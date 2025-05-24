using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class ReminderDTO
    {

        public int ReminderID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryID { get; set; }
        public int SelectedCategoryID { get; set; } 
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Please select  a task ")]
        public int TaskID { get; set; }

        public IEnumerable<SelectListItem> Tasks { get; set; }
        public string TaskName { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please Add a reminder date")]
        public DateTime ReminderDate { get; set; }
        public string NotificationMethod { get; set; }
        [Required(ErrorMessage = "Please Add a reminder Message")]
        public string ReminderMessage { get; set; }
        public string ReminderStatus { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required(ErrorMessage = "Please choose a wait period")]
        public string WaitType { get; set; } // 'Hour', 'Day', or 'Week'
        public int WaitPeriod { get; set; }
    }
}
