
namespace PokerHands
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public int Value { get; private set; }

        public Card(Suit suit, int value)
        {
            this.Suit = suit;
            this.Value = value;
        }
    }
}
