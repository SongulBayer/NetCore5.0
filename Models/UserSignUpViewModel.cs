using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "İsim Soyisim")]
        [Required(ErrorMessage = "Gerekli")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Gerekli")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Gerekli")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Gerekli")]
        public string UserName { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Gerekli")]
        public string Mail { get; set; }

    }
}
