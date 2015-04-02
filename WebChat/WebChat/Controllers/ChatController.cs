using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebChat.Models;
using WebChat.Services;
using WebChat.ViewModelHelpers;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoomAjax(string roomName)
        {
            if (Request.IsAuthenticated)
            {
                List<Chat> chat = ChatService.GetByRoomName(roomName);
                HttpCookie myCookie2 = new HttpCookie("RoomActive");
                myCookie2.Value = RoomService.GetByName(roomName).Id.ToString();
                Response.Cookies.Add(myCookie2);
                VisitService.SaveDateVisit(User.Identity.Name, roomName);
                return PartialView(ChatDetailsViewModelHelper.PopulateChatDetailsViewModelList(chat));
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult Room(string roomName)
        {
            if (Request.IsAuthenticated)
            {
                List<Chat> chat = ChatService.GetByRoomName(roomName);
                HttpCookie myCookie2 = new HttpCookie("RoomActive");
                myCookie2.Value = RoomService.GetByName(roomName).Id.ToString();
                Response.Cookies.Add(myCookie2);
                VisitService.SaveDateVisit(User.Identity.Name, roomName);
                return View(ChatDetailsViewModelHelper.PopulateChatDetailsViewModelList(chat));
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult NewMessage()
        {
            if (Request.IsAuthenticated)
            {
                String msg = Request.Form[0].ToString();
                HttpCookie myCookie = new HttpCookie("RoomActive");
                myCookie = Request.Cookies["RoomActive"];
                Chat chat = new Chat()
                {
                    Message = msg,
                    RoomId = Convert.ToInt32(myCookie.Value),
                    UserId = UserService.GetByLogin(User.Identity.Name).Id,
                    Date = DateTime.Now
                };
                ChatService.Create(chat);
                VisitService.SaveDateVisit(User.Identity.Name, RoomService.GetById(int.Parse(myCookie.Value)).Name);
                return RedirectToAction("Room", "Chat", new { roomName = RoomService.GetById(Convert.ToInt32(myCookie.Value)).Name });
            }

            return RedirectToAction("Login", "User");
        }

        public ActionResult CreateRoom()
        {
            if (Request.IsAuthenticated)
            {
                List<Room> roomList = RoomService.GetAll();
                Room newRoom = new Room()
                {
                    Name = ("Комната " + (roomList.Count + 1).ToString())
                };
                RoomService.Create(newRoom);
                return RedirectToAction("Room", "Chat", new { roomName = newRoom.Name });
            }

            return RedirectToAction("Login", "User");
        }

        public ActionResult TempRoom(string roomName)
        {
            if (Request.IsAuthenticated)
            {
                HttpCookie myCookie = new HttpCookie("RoomActive");
                myCookie = Request.Cookies["RoomActive"];
                VisitService.SaveDateVisit(User.Identity.Name, RoomService.GetById(int.Parse(myCookie.Value)).Name);
            }
            return RedirectToAction("Room", "Chat", new { roomName = roomName });
        }

        public ActionResult MenuAjax()
        {
            HttpCookie myCookie2 = new HttpCookie("RoomActive");
            myCookie2.Value = Request.Cookies["RoomActive"].Value;
            Response.Cookies.Add(myCookie2);
            return PartialView();
        }

    }
}
