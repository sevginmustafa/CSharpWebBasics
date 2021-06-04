using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services.Repositories
{
    public class RepositoriesService : IRepositoriesService
    {
        private ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(string name, string type, string userId)
        {
            var repository = new Repository()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = type == "Public" ? true : false,
                OwnerId = userId
            };

            this.db.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryOutputModel> GetAllPublic()
        {
            var repositories = this.db.Repositories
                .Where(x => x.IsPublic)
                .Select(x => new RepositoryOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    Owner = x.Owner.Username,
                    CommitsCount = x.Commits.Count
                })
                .ToList();

            return repositories;
        }
    }
}
