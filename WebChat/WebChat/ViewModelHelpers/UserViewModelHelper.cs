using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.ViewModels;

namespace WebChat.ViewModelHelpers
{
    public class UserViewModelHelper
    {
        public static UserViewModel PopulateUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id=user.Id,
                Name=user.Name,
                Password = user.Password,
                Login = user.Login
            };
        }
        public static List<UserViewModel> PopulateUserViewModelList(List<User> userList)
        {
            return userList.Select(s => PopulateUserViewModel(s)).ToList();
        }
    }
}