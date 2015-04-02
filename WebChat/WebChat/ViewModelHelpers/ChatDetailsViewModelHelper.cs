using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Services;
using WebChat.ViewModels;

namespace WebChat.ViewModelHelpers
{
    public class ChatDetailsViewModelHelper
    {
        public static ChatDetailsViewModel PopulateChatDetailsViewModel(Chat chat)
        {
            return new ChatDetailsViewModel
            {
                Id = chat.Id,
                UserName = UserService.GetById(chat.UserId).Name,
                RoomName = RoomService.GetById(chat.RoomId).Name,
                Message = chat.Message,
                CreateMassage = chat.Date
            };
        }
        public static List<ChatDetailsViewModel>
            PopulateChatDetailsViewModelList(List<Chat> chatList)
        {
            return chatList.Select(s => PopulateChatDetailsViewModel(s)).ToList();
        }
    }
}