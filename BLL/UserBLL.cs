using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        UserDAO userdao = new UserDAO();
        public UserDTO GetUserWithUserNameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            dto = userdao.GetUserWithUsernameAndPassword(model);
            return dto;
        }

        public UserDTO getLoggedUserDetails()
        {
            UserDTO dto = new UserDTO();
            dto = userdao.getLoggedUserDetails();
            return dto;

        }

        public void UpdateUser(UserDTO model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Username = model.Username;
            user.IsAdmin = true;//TODO:have roles and access levels
            user.PhoneNumber = model.PhoneNumber;
            user.UpdatedAt = DateTime.Now;

            userdao.UpdateUser(user);
            LogDAO.AddLog(General.ProcessType.UpdateUser, General.ProcessName.UpdateUser, UserStatic.UserID);

        }

        public void AddUser(UserDTO model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Username = model.Username;
            user.Email = model.Email;
            user.PasswordHash = model.Password;
            user.IsAdmin = true;//TODO:have roles and access levels for small teams
            user.PhoneNumber = model.PhoneNumber;
            user.CreatedAt = DateTime.Now;
            userdao.AddUser(user);
            //LogDAO.AddLog(General.ProcessType.AddUser, General.ProcessName.AddUser, UserStatic.UserID);

        }
    }
}
