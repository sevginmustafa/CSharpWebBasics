using Andreys.ViewModels.User;

namespace Andreys.Services.Users
{
    public interface IUsersService
    {
        void RegisterUser(UserRegisterViewModel model);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
