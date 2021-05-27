using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
