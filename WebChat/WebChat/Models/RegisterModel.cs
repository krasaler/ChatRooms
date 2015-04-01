using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Range(8,16,ErrorMessage="Никнейм должен быть от 8 до 16 символов")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }

        [Range(8,16,ErrorMessage="Никнейм должен быть от 8 до 16 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Пароли не совпадают")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }

    
    }
}