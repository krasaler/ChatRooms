using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.ViewModels;

namespace WebChat.ViewModelHelpers
{
    public class ChatEditViewModelHelper
    {
        public static ChatEditViewModel PopulateChatViewModel(Chat chat)
        {
            return new ChatEditViewModel
            {
                Id = chat.Id,
                UserId = chat.UserId,
                RoomId = chat.RoomId,
                Message = chat.Message,
                CreateMassage = chat.Date
            };
        }
        public static Chat PopulateChatFromEditViewModel(ChatEditViewModel model)
        {
            return new Chat
            {
                Id = model.Id,
                UserId = model.UserId,
                RoomId = model.RoomId,
                Message = model.Message,
                Date = model.CreateMassage
            };
        }
        public static void PopulateUserList(ChatEditViewModel model,
            List<User> userList)
        {
            model.UserList = new SelectList(userList, "Id", "Name");
        }
        public static void PopulateRoomList(ChatEditViewModel model,
            List<Room> roomList)
        {
            model.RoomList = new SelectList(roomList, "Id", "Name");
        }
    }
}