using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Git.Controllers
{
    public class Controller
    {
        public HttpResponse View([CallerMemberName] string path = null)
        {
            var readLayoutHtml = File.ReadAllText("Views/Shared/_Layout.cshtml");

            var layoutAsBytes = Encoding.UTF8.GetBytes(readLayoutHtml);

            var readHtml = File.ReadAllText("Views/" + GetType().Name.Replace("Controller", "/") + path + ".cshtml");

            var htmlAsBytes = Encoding.UTF8.GetBytes(readLayoutHtml.Replace("@RenderBody()", readHtml));

            var response = new HttpResponse("text/html", htmlAsBytes);

            return response;
        }

        public HttpResponse ViewFile(string path, string contentType)
        {
            var readFile = File.ReadAllBytes(path);

            var response = new HttpResponse(contentType, readFile);

            return response;
        }
    }
}
