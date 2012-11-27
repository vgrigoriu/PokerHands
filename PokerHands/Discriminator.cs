using System.Collections.Generic;

namespace PokerHands
{
    public class Discriminator : IDiscriminator
    {
        public int CompareEqual(IList<Card> firstHand, IList<Card> secondHand)
        {
            return 0;
        }
    }
}