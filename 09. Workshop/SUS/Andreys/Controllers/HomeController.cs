using Andreys.Services.Products;
using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Home();
            }

            return this.View();
        }

        public HttpResponse Home()
        {
            var model = this.productsService.GetAll();

            return this.View(model);
        }
    }
}
