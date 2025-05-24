using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DashletsDTO
    {
        public decimal TodaysTasks { get; set; }
        public int TodaysReminders { get; set; }
        public int CompletedTasks { get; set; }
        public decimal DeliveredReminders { get; set; }

        public string TaskChangePercentage { get; set; }
        public string ReminderChangePercentage { get; set; }
        public string CompletedTaskChangePercentage { get; set; }
        public string DeliveredReminderChangePercentage { get; set; }
    }
    
}
