using System;
using System.Collections.Generic;
using System.Linq;
using PokerHands.Exceptions;

namespace PokerHands
{
    public class PokerDealer
    {
        private readonly IDiscriminator _discriminator;

        private IDiscriminator Discriminator
        {
            get
            {
                if (_discriminator == null)
                    throw new InvalidOperationException("");
                return _discriminator;
            }
        }

        public PokerDealer()
        {
        }

        public PokerDealer(IDiscriminator discriminator)
        {

            this._discriminator = discriminator;
        }

        public int Compare(IList<Card> firstHand, IList<Card> secondHand)
        {
            // TODO if(firstHand == null)

            if (firstHand.Count != 5 || secondHand.Count != 5)
                throw new NotAPokerHandException();
            HandType firstHandType = GetHandType(firstHand);
            HandType secondHandType = GetHandType(secondHand);

            if ((int)firstHandType > (int)secondHandType)
                return -1;
            else if ((int)firstHandType < (int)secondHandType)
                return 1;

            return Discriminator.CompareEqual(firstHand, secondHand);

        }


        public HandType GetHandType(IList<Card> firstHand)
        {
            var distinctHand = firstHand.Select(card => card.Value).Distinct();

            if (distinctHand.Count() == 4)
                return HandType.OnePair;

            if (distinctHand.Count() == 3)
            {
                if (firstHand.Any(card => firstHand.Count(c => c.Value == card.Value) == 3))
                    return HandType.ThreeOfAKind;
                return HandType.TwoPair;
            }


            return HandType.HighCard;
        }
    }
}
