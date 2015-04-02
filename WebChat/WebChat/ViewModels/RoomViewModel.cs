using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Display(Name="Комната")]
        public string Name { get; set; }
    }
}