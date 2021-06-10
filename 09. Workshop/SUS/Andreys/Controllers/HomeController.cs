using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }

        public HttpResponse Home()
        {
            return this.View();
        }
    }
}
