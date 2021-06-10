using Andreys.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Data
{
    public class Product
    {
        public Product()
        {
            this.Users = new HashSet<UserPoduct>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Gender Gender { get; set; }


        public virtual ICollection<UserPoduct> Users { get; set; }
    }
}
