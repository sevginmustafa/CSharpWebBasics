using MyFirstMvcApp.Data;
using MyFirstMvcApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstMvcApp.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel model)
        {
            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description
            };

            db.Cards.Add(card);

            db.SaveChanges();

            return card.Id;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            var card = db.UsersCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (card != null)
            {
                return;
            }

            db.UsersCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });

            db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var card = db.UsersCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (card == null)
            {
                return;
            }

            db.UsersCards.Remove(card);

            db.SaveChanges();
        }

        public IEnumerable<CardsViewModel> GetAll()
        {
            return db.Cards.Select(x => new CardsViewModel
            {
                Id = x.Id,
                Attack = x.Attack,
                Health = x.Health,
                Name = x.Name,
                Keyword = x.Keyword,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).
            ToList();
        }

        public IEnumerable<CardsViewModel> GetAllCardsByUserId(string userId)
        {
            return db.UsersCards.Where(x => x.UserId == userId)
                .Select(x => new CardsViewModel
                {
                    Id = x.CardId,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Name = x.Card.Name,
                    Keyword = x.Card.Keyword,
                    Description = x.Card.Description,
                    ImageUrl = x.Card.ImageUrl
                })
                .ToList();
        }
    }
}
