using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }
    }
}