using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LibraryManagement.Models.Database;

namespace LibraryManagement.Models
{
   public class ProjectSession
    {
        #region "Property"
        public static User User
        {
            get
            {
                if (HttpContext.Current.Session["User"] == null)
                {
                    return null;
                }
                return (User)HttpContext.Current.Session["User"];
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }
        public static Role Role
        {
            get
            {
                if (HttpContext.Current.Session["Role"] == null)
                {

                    return null;
                }
                return (Role)HttpContext.Current.Session["Role"];
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
        }
        #endregion
    }
}
