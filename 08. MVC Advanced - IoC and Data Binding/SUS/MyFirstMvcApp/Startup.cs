using SUS.HTTP;
using SUS.MvcFramework;
using MyFirstMvcApp.Controllers;
using System.Collections.Generic;
using SUS.HTTP.Enums;
using MyFirstMvcApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            //throw new System.NotImplementedException();
        }

        public void Configure(List<Route> routeTable)
        {
            //new ApplicationDbContext().Database.Migrate();
        }
    }
}