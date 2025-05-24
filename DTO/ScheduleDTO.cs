using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ScheduleDTO
    {
        public string Title { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public string IconClass { get; set; } 
        public string Description { get; set; }
    }
}
