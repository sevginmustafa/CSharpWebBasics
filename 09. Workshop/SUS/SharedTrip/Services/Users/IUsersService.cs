using SharedTrip.ViewModels;

namespace SharedTrip.Services.Users
{
    public interface IUsersService
    {
        void RegisterUser(UserRegisterModel model);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
