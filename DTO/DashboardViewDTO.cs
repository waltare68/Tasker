using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DashboardViewDTO
    {
        public DashletsDTO DashletData { get; set; }
        public List<TaskDTO> TaskList { get; set; }
        public List<ScheduleDTO> ScheduleList { get; set; }
    }
}
