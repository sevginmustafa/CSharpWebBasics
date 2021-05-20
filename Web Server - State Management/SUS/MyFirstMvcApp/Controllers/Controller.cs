using SUS.HTTP;
using System.IO;
using System.Runtime.CompilerServices;

namespace MyFirstMvcApp.Controllers
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var responseHtml = File.ReadAllBytes("Views/" + this.GetType().Name.Replace("Controller", "/") + viewPath + ".html");

            HttpResponse response = new HttpResponse("text/html", responseHtml);

            return response;
        }

        public HttpResponse ViewFile(string path, string contentType)
        {
            var responseFile = File.ReadAllBytes(path);

            var response = new HttpResponse(contentType, responseFile);

            return response;
        }
    }
}
