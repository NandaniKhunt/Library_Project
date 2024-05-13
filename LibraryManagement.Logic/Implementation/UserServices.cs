using System;
using System.Linq;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models.Custom;
using LibraryManagement.Models;
using LibraryManagement.Models.Database;
using System.Data.Entity;


namespace LibraryManagement.Logic.Implementation
{
    public class UserServices : BaseServices, IUserServices
    {
        public User Authentication(string userName, string password)
        {
            var returnitem = db.User.FirstOrDefault(f => f.Username == userName && f.Password == password && f.IsDeleted == false);
            if (returnitem != null)
            {
                returnitem.LastLoginTime = DateTime.UtcNow;
                returnitem.LoginHistory = ""; 
                db.SaveChanges();
                return returnitem;
            }
            return null;
        }
          public void Update(User model)
        {
            var existingUser = db.User.FirstOrDefault(u => u.UserId == model.UserId);
            if (existingUser != null)
            {
                existingUser.Username = model.Username;
                existingUser.Password = model.Password;
                db.SaveChanges(); 
            }
        
        }
    }
}
