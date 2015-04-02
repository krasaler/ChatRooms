using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Services
{
    public class UserService
    {
        public static List<User> GetAll()
        {
            using (var context = new ChatEntities())
            {
                return context.User.ToList();
            }
        }
        public static User GetById(int userId)
        {
            using (var context = new ChatEntities())
            {
                return context.User.FirstOrDefault(s => s.Id == userId);
            }
        }
        public static User Get(string userName, string password)
        {
            var user = GetByLogin(userName);
            if (user != null)
                if (String.Compare(user.Password,password)<0)
                        return null;
            return user;
        }
        public static User GetByLogin(string userLogin)
        {
            using (var context = new ChatEntities())
            {
                return context.User.FirstOrDefault(s =>
                    s.Login == userLogin);
            }
        }
        public static void Save(User user)
        {
            using (var context = new ChatEntities())
            {
                context.User.Attach(user);
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Create(User user)
        {
            using (var context = new ChatEntities())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public static void Delete(User user)
        {
            using (var context = new ChatEntities())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public static bool IsExistedByName(string userName)
        {
            using (var context = new ChatEntities())
            {
                return context.User.Any(s => s.Login.ToUpper() == userName.ToUpper());
            }
        }
    }

}