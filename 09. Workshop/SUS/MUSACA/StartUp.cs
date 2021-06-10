using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;

namespace MUSACA
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
           // new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //throw new NotImplementedException();
        }
    }
}
