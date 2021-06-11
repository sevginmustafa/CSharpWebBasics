using Andreys.Services.Users;
using Andreys.ViewModels.User;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 4 || model.Username.Length > 10)
            {
                return this.Error("Username is required and shoud be between 4 and 10 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password is required and shoud be between 6 and 20 characters!");
            }

            if (!new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid Email address!");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username is already taken!");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email address is already taken!");
            }

            this.usersService.RegisterUser(model);

            return this.View();
        }

        [HttpGet("/Logout")]
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
