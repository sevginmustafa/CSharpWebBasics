using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.Commits
{
    public interface ICommitsService
    {
        void CreateCommit(string repositoryId, string description, string creatorId);

        IEnumerable<CommitOutputModel> GetAll(string userId);

        string GetRepositoryName(string repositoryId);

        void DeleteCommit(string id);
    }
}
