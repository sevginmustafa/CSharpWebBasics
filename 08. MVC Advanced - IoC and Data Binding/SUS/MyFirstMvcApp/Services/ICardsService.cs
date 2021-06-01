namespace MyFirstMvcApp.Services
{
    public interface ICardsService
    {
        void AddCard(string name, string imageUrl, string keyword, string attack, string health, string description);
    }
}
