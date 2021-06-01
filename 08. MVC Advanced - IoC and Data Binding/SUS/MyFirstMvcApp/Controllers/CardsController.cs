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
        private readonly ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(string name, string image, string keyword, string attack, string health, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (this.Request.FormData["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 symbols long!");
            }

            db.Cards.Add(new Card
            {
                Name = name,
                ImageUrl = image,
                Keyword = keyword,
                Attack = int.Parse(attack),
                Health = int.Parse(health),
                Description = description
            });

            db.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = db.Cards
                .Select(x => new CardsViewModel
                {
                    Attack = x.Attack,
                    Health = x.Health,
                    Name = x.Name,
                    Keyword = x.Keyword,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl
                })
            .ToList();

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}