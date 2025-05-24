using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : CSRMDBManager
    {
        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            User user = db.Users.FirstOrDefault(x => x.Username == model.Email && x.PasswordHash == model.Password);
            if (user != null && user.UserID != 0)
            {
                dto.ID = user.UserID;
                dto.Username = user.Username;
                dto.PhoneNumber = user.PhoneNumber;
                dto.Email = user.Email;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.AvatarUrl = user.AvatarUrl;
                dto.IsAdmin = user.IsAdmin;
            }
            return dto;
        }

        public UserDTO getLoggedUserDetails()
        {
            UserDTO dto = new UserDTO();
            var userID = UserStatic.UserID;
            User user = db.Users.FirstOrDefault(x => x.UserID == userID);
            if (user != null && user.UserID != 0)
            {
                dto.ID = user.UserID;
                dto.Username = user.Username;
                dto.PhoneNumber = user.PhoneNumber;
                dto.Email = user.Email;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.AvatarUrl = user.AvatarUrl;
                dto.IsAdmin = user.IsAdmin;
            }
            return dto;
        }

        public int AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.UserID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool UpdateUser(User user)
        {
            try
            {
                var existingUser = db.Users.Find(user.UserID);
                if (existingUser == null)
                {
                    throw new Exception("User not found.");
                }

                db.Entry(existingUser).CurrentValues.SetValues(user);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
