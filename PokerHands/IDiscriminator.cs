using System.Collections.Generic;

namespace PokerHands
{
    public interface IDiscriminator
    {
        int CompareEqual(System.Collections.Generic.IList<Card> firstHand, System.Collections.Generic.IList<Card> secondHand);
    }

    public class Discriminator : IDiscriminator
    {
        public int CompareEqual(IList<Card> firstHand, IList<Card> secondHand)
        {
            return 0;
        }
    }
}
