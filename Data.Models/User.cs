using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
