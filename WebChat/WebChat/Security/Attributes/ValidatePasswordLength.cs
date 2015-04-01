using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Security.Attributes
{
    public class ValidatePasswordLength : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string password = value.ToString();
           if(password.Length>=8)
                return true;
            return false;
        }
    }
}