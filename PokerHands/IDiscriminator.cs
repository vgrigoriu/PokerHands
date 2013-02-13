using System.Collections.Generic;

namespace PokerHands
{
    public interface IDiscriminator
    {
        Winner GetWinnerForHandsWithSameType(IList<Card> firstHand, IList<Card> secondHand);
    }
}
