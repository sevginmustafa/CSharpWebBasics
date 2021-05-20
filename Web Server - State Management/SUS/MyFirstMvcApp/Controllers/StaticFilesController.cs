using SUS.HTTP;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController:Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.ViewFile("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }
    }
}
