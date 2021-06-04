using Git.Data;
using Git.Services.Commits;
using Git.Services.Repositories;
using Git.Services.Users;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace Git
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
            System.Console.WriteLine("Ready");
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IRepositoriesService, RepositoriesService>();
            serviceCollection.Add<ICommitsService, CommitsService>();
        }
    }
}
