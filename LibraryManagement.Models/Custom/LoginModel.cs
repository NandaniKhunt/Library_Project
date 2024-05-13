using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Custom
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter username", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password", AllowEmptyStrings = false)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
