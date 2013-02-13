using System;
using System.Collections.Generic;
using System.Linq;
using PokerHands.Exceptions;

namespace PokerHands
{
    public class PokerDealer
    {
        private readonly IDiscriminatorFactory discriminatorFactory;

        private IDiscriminatorFactory DiscriminatorFactory
        {
            get
            {
                if (discriminatorFactory == null)
                    throw new InvalidOperationException("");
                return discriminatorFactory;
            }
        }

        public PokerDealer()
            : this(new DiscriminatorFactory())
        {

        }

        public PokerDealer(IDiscriminatorFactory discriminatorFactory)
        {
            this.discriminatorFactory = discriminatorFactory;
        }

        public Winner GetWinner(IList<Card> firstHand, IList<Card> secondHand)
        {
            if (firstHand == null) throw new ArgumentNullException("firstHand");
            if (secondHand == null) throw new ArgumentNullException("secondHand");

            if (firstHand.Count != 5 || secondHand.Count != 5)
                throw new NotAPokerHandException();
            HandType firstHandType = GetHandType(firstHand);
            HandType secondHandType = GetHandType(secondHand);

            if ((int)firstHandType > (int)secondHandType)
                return Winner.First;
            if ((int)firstHandType < (int)secondHandType)
                return Winner.Second;

            IDiscriminator discriminator = DiscriminatorFactory.CreateDiscriminator(firstHandType);
            return discriminator.GetWinnerForHandsWithSameType(firstHand, secondHand);
        }

        public HandType GetHandType(IList<Card> hand)
        {
            var distinctValueCount = hand.Select(card => card.Value).Distinct().Count();

            var sortedHand = hand.OrderBy(card => card.Value);
            var distinctSuits = sortedHand.Select(card => card.Suit).Distinct().Count();

            switch (distinctValueCount)
            {
                case 2:
                    return GetHandTypeForTwoDistinctCardValues(sortedHand);
                case 3:
                    return GetHandTypeForThreeDistinctCardValues(hand);
                case 4:
                    return HandType.OnePair;
                case 5:
                    return GetHandTypeForFiveDistinctCardValues(sortedHand, distinctSuits);
                default:
                    throw new NotAPokerHandException();
            }
        }

        private static HandType GetHandTypeForThreeDistinctCardValues(IList<Card> hand)
        {
            if (hand.Any(card => hand.Count(c => c.Value == card.Value) == 3))
                return HandType.ThreeOfAKind;
            return HandType.TwoPair;
        }

        private static HandType GetHandTypeForTwoDistinctCardValues(IOrderedEnumerable<Card> sortedHand)
        {
            int firstCardValue = sortedHand.First().Value;
            int firstCardOccurences = sortedHand.Count(c => c.Value == firstCardValue);
            if (firstCardOccurences == 4 || firstCardOccurences == 1)
            {
                return HandType.FourofAKind;
            }
            return HandType.FullHouse;
        }


        /// <summary>
        /// </summary>
        /// <param name="sortedHand">a sorted list of five cards</param>
        /// <param name="distinctSuits">the number of distinct suits</param>
        /// <returns></returns>
        public HandType GetHandTypeForFiveDistinctCardValues(IOrderedEnumerable<Card> sortedHand, int distinctSuits)
        {
            if (distinctSuits == 1)
                if (sortedHand.Last().Value - sortedHand.First().Value == 4)
                {
                    if (sortedHand.Last().Value == 14)
                        return HandType.RoyalFlush;
                    else
                        return HandType.StraightFlush;
                }
                else
                    return HandType.Flush;

            if (sortedHand.Last().Value - sortedHand.First().Value == 4)
                return HandType.Straight;


            return HandType.HighCard;
        }
    }
}
