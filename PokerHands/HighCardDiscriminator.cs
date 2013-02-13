using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HighCardDiscriminator : IDiscriminator
    {
        public Winner GetWinnerForHandsWithSameType(IList<Card> firstHand, IList<Card> secondHand)
        {
            var orderedFirstHand = firstHand.OrderByDescending(c => c.Value).ToList();
            var orderedSecondHand = secondHand.OrderByDescending(c => c.Value).ToList();

            for (int i = 0; i < orderedFirstHand.Count; i++)
            {
                if (orderedFirstHand[i].Value > orderedSecondHand[i].Value)
                    return Winner.First;
                if (orderedFirstHand[i].Value < orderedSecondHand[i].Value)
                    return Winner.Second;
            }

            return Winner.None;
        }
    }
}