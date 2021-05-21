using SUS.HTTP;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var layout = File.ReadAllText("Views/Shared/_Layout.cshtml");

            var viewContent = File.ReadAllText("Views/" + this.GetType().Name.Replace("Controller", "/") + viewPath + ".cshtml");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);

            var reponseAsBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse response = new HttpResponse("text/html", reponseAsBytes);

            return response;
        }

        public HttpResponse ViewFile(string path, string contentType)
        {
            var responseFile = File.ReadAllBytes(path);

            var response = new HttpResponse(contentType, responseFile);

            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));

            return response;
        }
    }
}
