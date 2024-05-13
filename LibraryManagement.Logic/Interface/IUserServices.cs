using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models.Database;
using LibraryManagement.Models.Custom;

namespace LibraryManagement.Logic.Interface
{
    public interface IUserServices
    {
       User Authentication(string userName, string password);
       void Update(User model);
    }
}
