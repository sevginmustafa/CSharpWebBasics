using MUSACA.Data.Enums;
using System;

namespace MUSACA.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IdentityRole Role { get; set; }
    }
}
