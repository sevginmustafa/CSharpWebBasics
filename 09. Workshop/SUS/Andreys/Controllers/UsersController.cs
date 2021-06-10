using Andreys.Services.Users;
using Andreys.ViewModels.User;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login()
        {


            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }


            return this.View();
        }
    }
}
