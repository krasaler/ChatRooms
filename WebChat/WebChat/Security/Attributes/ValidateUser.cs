using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebChat.Services;

namespace WebChat.Security.Attributes
{
    public class ValidateUser : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string userName = value.ToString();
            if (!UserService.IsExistedByName(userName))
                return true;
            return false;
        }
    }
}