using Andreys.Data;
using Andreys.ViewModels.User;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Andreys.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password) =>
            this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == ComputeHash(password))?.Id;

        public bool IsEmailAvailable(string email) =>
            !this.db.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username) =>
            !this.db.Users.Any(x => x.Username == username);

        public void RegisterUser(UserRegisterViewModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = ComputeHash(model.Password)
            };

            this.db.Users.Add(user);

            this.db.SaveChanges();
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
