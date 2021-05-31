using System;
using SUS.HTTP;
using SUS.MvcFramework;
using MyFirstMvcApp.ViewModels;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to BattleCards";

            if (this.IsUserSignedIn())
            {
                viewModel.Message="Welcome User!";
            }

            return this.View(viewModel);
        }

        public HttpResponse About()
        {
            this.SignIn("sevgin");
            return this.View();
        }
    }
}