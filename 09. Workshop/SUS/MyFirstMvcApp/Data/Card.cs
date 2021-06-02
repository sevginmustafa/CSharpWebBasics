using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMvcApp.Data
{
    public class Card
    {
        public Card()
        {
            this.Users = new HashSet<UserCard>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Range(0, int.MaxValue)]
        public int Attack { get; set; }

        [Range(0, int.MaxValue)]
        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }


        public virtual ICollection<UserCard> Users { get; set; }
    }
}
