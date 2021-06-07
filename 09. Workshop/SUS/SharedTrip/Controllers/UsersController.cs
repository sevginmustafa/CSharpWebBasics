using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
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

        [HttpGet]
        public HttpResponse Register(UserRegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username is required and shoud be between 5 and 20 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password is required and shoud be between 6 and 20 characters!");
            }

            return this.View();
        }
    }
}
