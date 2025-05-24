using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Please fill the Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please fill the Email")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DOB { get; set; }

        public Boolean IsAdmin { get; set; }
        public int NotificationsEnabled { get; set; }


    }
}
