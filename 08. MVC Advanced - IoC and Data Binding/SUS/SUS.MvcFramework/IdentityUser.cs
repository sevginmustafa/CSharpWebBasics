using System.ComponentModel.DataAnnotations;

namespace SUS.MvcFramework
{
    public class IdentityUser<T>
    {
        public T Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public IdentityRole Role { get; set; }
    }
}
