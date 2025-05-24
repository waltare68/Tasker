using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class TestTasks
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // This property will hold a state, selected by user
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> States { get; set; }
    }
}
