using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.UI.ViewModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email is requeired")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage ="Password must be minimum 4 characters")]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
