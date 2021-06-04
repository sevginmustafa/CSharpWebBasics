using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services.Repositories
{
    public interface IRepositoriesService
    {
        void CreateRepository(string name, string type, string userId);

        IEnumerable<RepositoryOutputModel> GetAllPublic();
    }
}
