using MyFirstMvcApp.ViewModels;
using System.Collections.Generic;

namespace MyFirstMvcApp.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardInputModel model);

        IEnumerable<CardsViewModel> GetAll();

        IEnumerable<CardsViewModel> GetAllCardsByUserId(string userId);

        void AddCardToUserCollection(string userId, int cardId); 
        
        void RemoveCardFromUserCollection(string userId, int cardId);
    }
}
