using Git.Services.Users;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Git.Controllers
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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            if (this.usersService.GetUserId(username, password) == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(this.usersService.GetUserId(username, password));

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords not equal!");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username is required and should be between 5 and 20 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Email is required!");
            }

            if (!new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid email!");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 6 and 20 characters!");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username already exists!");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email already exists!");
            }

            this.usersService.RegisterUser(model);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
