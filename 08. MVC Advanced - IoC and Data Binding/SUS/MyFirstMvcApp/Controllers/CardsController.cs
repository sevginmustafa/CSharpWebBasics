using MyFirstMvcApp.Data;
using MyFirstMvcApp.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var context = new ApplicationDbContext();

            if (this.Request.FormData["name"].Length<5)
            {
                return this.Error("Name should be at least 5 symbols long!");
            }

            context.Cards.Add(new Card
            {
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"]
            });

            context.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            var db = new ApplicationDbContext();

            var cards = db.Cards
                .Select(x => new CardsViewModel
            {
                Attack=x.Attack,
                Health=x.Health,
                Name=x.Name,
                Keyword=x.Keyword,
                Description=x.Description,
                ImageUrl=x.ImageUrl
            })
            .ToList();

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}