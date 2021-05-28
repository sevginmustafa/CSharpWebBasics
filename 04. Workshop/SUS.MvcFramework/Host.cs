using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication mvcApplication, int port = 80)
        {
            List<Route> routeTable = new List<Route>();

            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);

            await server.StartAsync(80);
        }
    }
}
