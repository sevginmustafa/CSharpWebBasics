using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using MyFirstMvcApp.Data;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Services;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}