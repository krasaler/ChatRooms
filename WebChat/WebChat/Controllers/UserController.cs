using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            User newUser = new User();
            return View(newUser);
        }
        
        [HttpPost]
        public ActionResult Register(User user)
        {
            User newUser = new User();
            return View(newUser);
        }

    }
}
