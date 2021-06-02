using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }
    }
}