using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services.Commits
{
    public class CommitsService : ICommitsService
    {
        private ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateCommit(string repositoryId, string description, string creatorId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = repositoryId
            };

            this.db.Add(commit);

            this.db.SaveChanges();
        }

        public void DeleteCommit(string id)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == id);

            this.db.Commits.Remove(commit);

            this.db.SaveChanges();
        }

        public IEnumerable<CommitOutputModel> GetAll(string userId)
        {
            var commits = this.db.Commits.Where(x => x.CreatorId == userId)
                .Select(x => new CommitOutputModel
                {
                    Id=x.Id,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                }).ToList();

            return commits;
        }

        public string GetRepositoryName(string repositoryId)
        {
            return this.db.Repositories.FirstOrDefault(x => x.Id == repositoryId)?.Name;
        }
    }
}
