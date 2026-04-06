using playingcards.Models;

namespace playingcards.Services
{
    internal class Game
    {
        private readonly List<Card> cards = [];
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public string CardString(int index)
        {
            return cards[index].ToString()!;
        }
        public bool CardBeats(int cardA, int cardB)
        {
            return cards[cardA].CardValue > cards[cardB].CardValue;
        }
    }
}