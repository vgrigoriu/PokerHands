using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HighCardDiscriminator : IDiscriminator
    {
        public int CompareEqual(IList<Card> firstHand, IList<Card> secondHand)
        {
            var orderedFirstHand = firstHand.OrderByDescending(c => c.Value).ToList();
            var orderedSecondHand = secondHand.OrderByDescending(c => c.Value).ToList();

            for (int i = 0; i < orderedFirstHand.Count; i++)
            {
                if (orderedFirstHand[i].Value > orderedSecondHand[i].Value)
                    return -1;
                if (orderedFirstHand[i].Value < orderedSecondHand[i].Value)
                    return 1;
            }

            return 0;
        }
    }
}