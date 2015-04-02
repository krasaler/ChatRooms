using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat.Services
{
    public class ChatService
    {
        public static int NewMessage(string userName, string roomName)
        {
            Visit visit = VisitService.GetDateVisit(userName, roomName);
            List<Chat> chatList = GetByRoomName(roomName);
            if (visit != null)
            {
                return chatList.Where(s => s.Date > visit.LastVisit).ToList().Count;
            }
            else
            {

                return chatList.Count;
            }
        }
        public static int GetCountMessageForRoom(string roomName)
        {
            using (var context = new ChatEntities())
            {
                return context.Chat.Where(s => s.RoomId == RoomService.GetByName(roomName).Id).ToList().Count;
            }

        }
        public static Chat GetById(int chatId)
        {
            using (var context = new ChatEntities())
            {
                return context.Chat.FirstOrDefault(s => s.Id == chatId);
            }
        }
        public static List<Chat> GetByRoomName(string roomName)
        {
            using (var context = new ChatEntities())
            {
                Room room = RoomService.GetByName(roomName);
                return context.Chat.Where(s => s.RoomId == room.Id).ToList();
            }

        }
        public static List<Chat> GetByUserName(string userName)
        {
            using (var context = new ChatEntities())
            {
                User user = UserService.GetByLogin(userName);
                return context.Chat.Where(s => s.UserId == user.Id).ToList();
            }
        }
        public static List<Chat> GetAll()
        {
            using (var context = new ChatEntities())
            {
                return context.Chat.ToList();
            }
        }
        public static void Save(Chat chat)
        {
            using (var context = new ChatEntities())
            {
                context.Chat.Attach(chat);
                context.Entry(chat).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Create(Chat chat)
        {
            using (var context = new ChatEntities())
            {
                context.Chat.Add(chat);
                context.SaveChanges();
            }
        }
        public static void Delete(Chat chat)
        {
            using (var context = new ChatEntities())
            {
                context.Entry(chat).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}