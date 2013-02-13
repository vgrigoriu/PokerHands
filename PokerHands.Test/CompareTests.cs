using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands.Exceptions;

namespace PokerHands.Test
{
    [TestClass]
    public class CompareTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotAPokerHandException))]
        public void CompareValidatesNumberOfCards()
        {
            var list1 = new List<Card>
                {
                    new Card(Suit.Clubs, 2), 
                    new Card(Suit.Diamonds, 3),
                    new Card(Suit.Clubs, 2), 
                    new Card(Suit.Hearts, 11),
                    new Card(Suit.Spades, 12),
                };

            var list2 = new List<Card>
                {
                    new Card(Suit.Spades, 14), 
                    new Card(Suit.Diamonds, 10),
                    new Card(Suit.Clubs, 12), 
                    new Card(Suit.Hearts, 5),
                };

            var dealer = new PokerDealer();
            dealer.Compare(list1, list2);
            Assert.Fail("Shouldn't even reach this line");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareThrowsForNullArguments()
        {
            var dealer = new PokerDealer();
            dealer.Compare(null, null);
            Assert.Fail("Shouldn't even reach this line");
        }

        [TestMethod]
        [Ignore]
        public void HandsWithSameCardValuesAreEqual()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                    new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                    new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var secondHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                    new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                    new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var value = dealer.Compare(firstHand, secondHand);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void CompareHandWithHigherHandTypeWins()
        {
            var threeOfAKindHand = new List<Card>
            {
                new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1),
                new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2),
                new Card(Suit.Spades, 12)
            };

            var onePairHand = new List<Card>
            {
                new Card(Suit.Clubs, 2), 
                new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3),
                new Card(Suit.Hearts, 11),
                new Card(Suit.Spades, 12)
            };

            var value = new PokerDealer().Compare(threeOfAKindHand, onePairHand);

            Assert.AreEqual(Winner.First, value);
        }



    }
}