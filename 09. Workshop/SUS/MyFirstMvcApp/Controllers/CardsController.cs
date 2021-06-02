using MyFirstMvcApp.Services;
using MyFirstMvcApp.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 5 || model.Name.Length > 15)
            {
                return this.Error("Name is reequired and should be between 5 and 15 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                return this.Error("ImageUrl is required!");
            }

            if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return this.Error("Keyword is required!");
            }

            if (model.Attack < 0)
            {
                return this.Error("Attack must be positive number!");
            }

            if (model.Health < 0)
            {
                return this.Error("Health must be positive number!");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                return this.Error("Description is required and should be less than 200 characters!");
            }

            int cardId = this.cardsService.AddCard(model);

            this.AddToCollection(cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardsService.GetAll();

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardsService.GetAllCardsByUserId(this.GetUserId());

            return this.View(cards);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.cardsService.AddCardToUserCollection(this.GetUserId(), cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.cardsService.RemoveCardFromUserCollection(this.GetUserId(), cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}