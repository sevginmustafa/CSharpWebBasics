using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace SharedTrip.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
