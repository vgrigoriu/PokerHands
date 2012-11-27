using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Test
{
    [TestClass]
    public class GetHandTypeTests
    {
        [TestMethod]
        public void GetHandTypeDetectsOnePair()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };
            var dealer = new PokerDealer();

            var handType = dealer.GetHandType(firstHand);
            Assert.AreEqual(HandType.OnePair, handType);
        }

        [TestMethod]
        public void GetHandTypeDetectsHighCard()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };
            var dealer = new PokerDealer();
            var handtype = dealer.GetHandType(firstHand);
            Assert.AreEqual(handtype, HandType.HighCard);
        }

        [TestMethod]
        public void GetHandTypeDetectsTwoPairs()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.TwoPair);
        }

        [TestMethod]
        public void GetHandTypeDetectsThreeOfAKind()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.ThreeOfAKind);
        }
    }
}

