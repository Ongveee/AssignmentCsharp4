using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AssignmentCsharp4_hieuptph18134.ModelView
{
    public class LoginViewModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email:")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu:")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]        
        [MinLength(5, ErrorMessage = "Mật khẩu tối thiểu 5 ký tự")]
        public string Password { get; set; }
    }
}
