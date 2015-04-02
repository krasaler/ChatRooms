using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.ViewModels
{
    public class ChatDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Пользователь")]
        public string UserName { get; set; }

        [Display(Name = "Комната")]
        public string RoomName { get; set; }

        [Display(Name = "Сообщение")]
        public string Message { get; set; }

        [Display(Name = "Дата создания сообщения")]
        public DateTime CreateMassage { get; set; }
    }
}