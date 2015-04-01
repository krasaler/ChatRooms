using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name="Имя пользователя")]
        public string Name { get; set; }

        [Display(Name="Никнейм")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
    
    }
}