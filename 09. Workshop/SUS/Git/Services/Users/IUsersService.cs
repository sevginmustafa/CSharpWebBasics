using Git.ViewModels;

namespace Git.Services.Users
{
    public interface IUsersService
    {
        void RegisterUser(UserInputModel model);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
