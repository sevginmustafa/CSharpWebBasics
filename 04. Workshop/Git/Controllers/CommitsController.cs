using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        public HttpResponse All(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Create(HttpRequest request)
        {
            return this.View();
        }
    }
}
