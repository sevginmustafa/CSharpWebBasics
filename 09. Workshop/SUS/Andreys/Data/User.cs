using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<UserPoduct>();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        public virtual ICollection<UserPoduct> Products { get; set; }
    }
}
