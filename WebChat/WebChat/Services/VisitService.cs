using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat.Services
{
    public class VisitService
    {

        public static Visit GetDateVisit(string userName, string roomName)
        {
            return GetByRoomNameAndUserName(userName, roomName);
        }
        public static void SaveDateVisit(string userName, string roomName)
        {
            using (var context = new ChatEntities())
            {
                Visit visit = GetByRoomNameAndUserName(userName, roomName);
             
                if (visit != null)
                {
                    Visit newVisit = new Visit()
                    {
                        Id = visit.Id,
                        UserId = visit.UserId,
                        RoomId = visit.RoomId,
                        LastVisit = DateTime.Now
                    };
                    Save(newVisit);
                }
                else
                {
                    Room room = RoomService.GetByName(roomName);
                    User user = UserService.GetByLogin(userName);
                    Visit newVisit = new Visit()
                    {
                        UserId = user.Id,
                        RoomId = room.Id,
                        LastVisit = DateTime.Now
                    };
                    Create(newVisit);
                }
            }
        }
        public static Visit GetByRoomNameAndUserName(string userName, string roomName)
        {
            using (var context = new ChatEntities())
            {
                Room room = RoomService.GetByName(roomName);
                User user = UserService.GetByLogin(userName);
                return context.Visit.FirstOrDefault(s => (s.RoomId == room.Id) & (s.UserId == user.Id));
            }
        }
        public static Visit GetById(int visitId)
        {
            using (var context = new ChatEntities())
            {
                return context.Visit.FirstOrDefault(s => s.Id == visitId);
            }
        }
        public static List<Visit> GetByRoomName(string roomName)
        {
            using (var context = new ChatEntities())
            {
                Room room = RoomService.GetByName(roomName);
                return context.Visit.Where(s => s.RoomId == room.Id).ToList();
            }

        }
        public static List<Visit> GetByUserName(string userName)
        {
            using (var context = new ChatEntities())
            {
                User user = UserService.GetByLogin(userName);
                return context.Visit.Where(s => s.UserId == user.Id).ToList();
            }
        }
        public static List<Visit> GetAll()
        {
            using (var context = new ChatEntities())
            {
                return context.Visit.ToList();
            }
        }
        public static void Save(Visit visit)
        {
            using (var context = new ChatEntities())
            {
                context.Visit.Attach(visit);
                context.Entry(visit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Create(Visit visit)
        {
            using (var context = new ChatEntities())
            {
                context.Visit.Add(visit);
                context.SaveChanges();
            }
        }
        public static void Delete(Visit visit)
        {
            using (var context = new ChatEntities())
            {
                context.Entry(visit).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}