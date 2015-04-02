using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.ViewModels
{
    public class ChatEditViewModel
    {
        public int Id { get; set; }

        [Display(Name="Пользователь")]
        public int UserId { get; set; }
        public SelectList UserList { get; set; }

        [Display(Name = "Комната")]
        public int RoomId { get; set; }
        public SelectList RoomList { get; set; }

        [Display(Name="Сообщение")]
        public string Message { get; set; }

        [Display(Name="Дата создания сообщения")]
        public DateTime CreateMassage { get; set; }
    }
}