using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.ViewModels;

namespace WebChat.ViewModelHelpers
{
    public class RoomViewModelHelper
    {
        public static RoomViewModel PopulateUserViewModel(Room room)
        {
            return new RoomViewModel
            {
                Id = room.Id,
                Name = room.Name
            };
        }
        public static List<RoomViewModel> PopulateUserViewModelList(List<Room> roomList)
        {
            return roomList.Select(s => PopulateUserViewModel(s)).ToList();
        }
    }
}