using System;
using System.Collections.Generic;
using System.Linq;
using PokerHands.Exceptions;

namespace PokerHands
{
    public class PokerDealer
    {
        private readonly IDiscriminator discriminator;

        private IDiscriminator Discriminator
        {
            get
            {
                if (discriminator == null)
                    throw new InvalidOperationException("");
                return discriminator;
            }
        }

        public PokerDealer()
        {
        }

        public PokerDealer(IDiscriminator discriminator)
        {
            this.discriminator = discriminator;
        }

        public int Compare(IList<Card> firstHand, IList<Card> secondHand)
        {
            if (firstHand == null) throw new ArgumentNullException("firstHand");
            if (secondHand == null) throw new ArgumentNullException("secondHand");

            if (firstHand.Count != 5 || secondHand.Count != 5)
                throw new NotAPokerHandException();
            HandType firstHandType = GetHandType(firstHand);
            HandType secondHandType = GetHandType(secondHand);

            if ((int)firstHandType > (int)secondHandType)
                return -1;
            if ((int)firstHandType < (int)secondHandType)
                return 1;

            return Discriminator.CompareEqual(firstHand, secondHand);

        }


        public HandType GetHandType(IList<Card> hand)
        {
            var distinctValues = hand.Select(card => card.Value).Distinct().Count();

            if (distinctValues == 4)
                return HandType.OnePair;

            if (distinctValues == 3)
            {
                if (hand.Any(card => hand.Count(c => c.Value == card.Value) == 3))
                    return HandType.ThreeOfAKind;
                return HandType.TwoPair;
            }


            return HandType.HighCard;
        }
    }
}
