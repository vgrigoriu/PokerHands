using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands
{
    class TwoPairDiscriminator: IDiscriminator
    {
        public int CompareEqual(IList<Card> firstHand, IList<Card> secondHand)
        {
            return 1;
        }
    }
}
