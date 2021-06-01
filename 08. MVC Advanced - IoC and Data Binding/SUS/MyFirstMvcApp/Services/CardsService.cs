using MyFirstMvcApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(string name, string imageUrl, string keyword, string attack, string health, string description)
        {
            throw new NotImplementedException();
        }
    }
}
