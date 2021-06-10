using Andreys.Data;
using Andreys.Services.Products;
using Andreys.Services.Users;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace Andreys
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
            System.Console.WriteLine("Ready!");
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}
