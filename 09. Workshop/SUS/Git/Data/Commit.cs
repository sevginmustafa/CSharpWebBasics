using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public string RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
    }
}
