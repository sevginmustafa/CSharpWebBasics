using SharedTrip.Services.Users;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace SharedTrip.Controllers
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

            var user = this.usersService.GetUserId(username, password);

            if (user == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(user);

            return this.Redirect("/Trips/All");
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
        public HttpResponse Register(UserRegisterModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username is required and shoud be between 5 and 20 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Email is required!");
            }

            if (!new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Email is not valid!");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password is required and shoud be between 6 and 20 characters!");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username is already taken!");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email is already taken!");
            }

            this.usersService.RegisterUser(model);

            return this.Redirect("/Users/Login");
        }
    }
}
