using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebChat.Models;
using WebChat.Services;

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
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel regmod)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Id = regmod.Id,
                    Name = regmod.Name,
                    Login = regmod.Login,
                    Password = regmod.Password
                };
                UserService.Create(user);

                FormsAuthentication.SetAuthCookie(user.Name, true);

                return RedirectToAction("Index", "Home", new { area = "" });

            }
            return View(regmod);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var user =UserService.Get(model.Login, model.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Name, model.RememberMe);

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
                    }
                }

            }
            catch (Exception)
            {

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
