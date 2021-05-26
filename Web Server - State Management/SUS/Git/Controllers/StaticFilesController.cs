using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Git.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.ViewFile("wwwroot/img/favicon.ico", "image/vnd.microsoft.icon");
        }

        public HttpResponse BootstrapCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/bootstrap/bootstrap.min.css", "text/css");
        }

        public HttpResponse BootstrapJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/bootstrap/bootstrap.min.js", "text/javascript");
        }

        public HttpResponse JqueryJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/jquery/jquery.min.js", "text/javascript");
        }

        public HttpResponse NouisliderMinCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/nouislider/css/nouislider.min.css", "text/css");
        }

        public HttpResponse NouisliderCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/nouislider/css/nouislider.css", "text/css");
        }

        public HttpResponse NouisliderJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/nouislider/js/nouislider.js", "text/javascript");
        }

        public HttpResponse NouisliderMinJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/nouislider/js/nouislider.min.js", "text/javascript");
        }

        public HttpResponse PopperMinJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/popper/popper.min.js", "text/javascript");
        }

        public HttpResponse PopperJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/popper/popper.js", "text/javascript");
        }

        public HttpResponse PrismJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/prism/prism.js", "text/javascript");
        }

        public HttpResponse PrismCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/vendor/prism/prism.css", "text/css");
        }

        public HttpResponse DemoCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/css/demo.css", "text/css");
        }

        public HttpResponse LazyCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/css/lazy.css", "text/css");
        }

        public HttpResponse ResetCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/css/reset-css.css", "text/css");
        }

        public HttpResponse SiteCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/css/site.css", "text/css");
        }

        public HttpResponse DemoJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/js/demo.js", "text/javascript");
        }

        public HttpResponse LazyJs(HttpRequest request)
        {
            return this.ViewFile("wwwroot/js/lazy.js", "text/javascript");
        }

        public HttpResponse TextCss(HttpRequest request)
        {
            return this.ViewFile("wwwroot/css/text.css", "text/css");
        }
    }
}
