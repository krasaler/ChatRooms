﻿using LessonProject.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace LessonProject.Global.Auth
{
    public class CustomAuthentication :IAuthentication
    {
        //Логгер
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //Имя куков
        private const string cookieName = "__AUTH_COOKIE";
        //Конекст
        public HttpContext HttpContext { get; set; }
        //Репозитория БД
        [Inject]
        public IRepository Repository { get; set; }

        #region IAuthentication Members
        //Конструктор
        public User Login(string userName, string Password, bool isPersistent)
        {
            User retUser = Repository.Login(userName, Password);
            if (retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }
            return retUser;
        }
        //Конструктор
        public User Login(string userName)
        {
            User retUser = Repository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
            if (retUser != null)
            {
                CreateCookie(userName);
            }
            return retUser;
        }
        //Создание куков
        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication: " + ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }
        #endregion
    }
}