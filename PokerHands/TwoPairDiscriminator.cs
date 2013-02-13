using System.Collections.Generic;

namespace PokerHands
{
    class TwoPairDiscriminator : IDiscriminator
    {
        public Winner GetWinnerForHandsWithSameType(IList<Card> firstHand, IList<Card> secondHand)
        {
            return Winner.Second;
        }
    }
}
