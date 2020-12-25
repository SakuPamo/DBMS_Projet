using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMSProjet.Database
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Provide password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}