using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.ViewModels;

namespace WebChat.ViewModelHelpers
{
    public class VisitEditViewModelHelper
    {
        public static VisitEditViewModel PopulateVisitViewModel(Visit visit)
        {
            return new VisitEditViewModel
            {
                Id = visit.Id,
                UserId = visit.UserId,
                RoomId = visit.RoomId,
                LastVisit = visit.LastVisit
            };
        }
        public static Visit PopulateVisitFromEditViewModel(VisitEditViewModel model)
        {
            return new Visit
            {
                Id = model.Id,
                UserId = model.UserId,
                RoomId = model.RoomId,
                LastVisit = model.LastVisit
            };
        }
        public static void PopulateUserList(VisitEditViewModel model,
            List<User> userList)
        {
            model.UserList = new SelectList(userList, "Id", "Name");
        }
        public static void PopulateRoomList(VisitEditViewModel model,
            List<Room> roomList)
        {
            model.RoomList = new SelectList(roomList, "Id", "Name");
        }
    }
}