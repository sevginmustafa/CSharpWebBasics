using SUS.HTTP;
using System;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/login", Login);

            await server.StartAsync(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
