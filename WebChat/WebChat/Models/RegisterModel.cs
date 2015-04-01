using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebChat.Security.Attributes;

namespace WebChat.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [ValidateUser(ErrorMessage = "Пользователь с таким именем уже существует")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [ValidatePasswordLength(ErrorMessage="Пароль должен быть длинее 8 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Compare("Password",ErrorMessage="Пароли не совпадают")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }

    
    }
}