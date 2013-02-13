namespace PokerHands
{
    public interface IDiscriminator
    {
        Winner CompareEqual(System.Collections.Generic.IList<Card> firstHand, System.Collections.Generic.IList<Card> secondHand);
    }
}
