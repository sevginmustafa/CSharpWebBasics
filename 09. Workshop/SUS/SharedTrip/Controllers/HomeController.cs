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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}
