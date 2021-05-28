using SUS.HTTP;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.ViewFile("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }

        internal HttpResponse BootstrapCss(HttpRequest arg)
        {
            return this.ViewFile("wwwroot/css/bootstrap.min.css", "text/css");
        }

        internal HttpResponse CustomCss(HttpRequest arg)
        {
            return this.ViewFile("wwwroot/css/custom.css", "text/css");
        }

        internal HttpResponse BootstrapJs(HttpRequest arg)
        {
            return this.ViewFile("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }

        internal HttpResponse CustomJs(HttpRequest arg)
        {
            return this.ViewFile("wwwroot/js/custom.js", "text/javascript");
        }
    }
}
