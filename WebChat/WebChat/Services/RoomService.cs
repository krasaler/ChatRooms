using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Services
{
    public class RoomService
    {
        public static List<Room> GetAll()
        {
            using (var context = new ChatEntities())
            {
                return context.Room.ToList();
            }
        }
        public static Room GetById(int roomId)
        {
            using (var context = new ChatEntities())
            {
                return context.Room.FirstOrDefault(s => s.Id == roomId);
            }
        }
        public static Room GetByName(string roomName)
        {
            using (var context = new ChatEntities())
            {
                return context.Room.FirstOrDefault(s => s.Name.Trim() == roomName);
            }
        }
        public static void Save(Room room)
        {
            using (var context = new ChatEntities())
            {
                context.Room.Attach(room);
                context.Entry(room).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Create(Room room)
        {
            using (var context = new ChatEntities())
            {
                context.Room.Add(room);
                context.SaveChanges();
            }
        }

        public static void Delete(Room room)
        {
            using (var context = new ChatEntities())
            {
                context.Entry(room).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public static bool IsExistedByName(string roomName)
        {
            using (var context = new ChatEntities())
            {
                return context.Room.Any(s => s.Name.ToUpper() == roomName.ToUpper());
            }
        }
    }
}