using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Test
{
    [TestClass]
    public class GetHandTypeTests
    {
        private PokerDealer dealer;
        
        [TestInitialize]
        public void SetUp()
        {
            dealer = new PokerDealer();
        }

        [TestMethod]
        public void GetHandTypeDetectsOnePair()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };
            

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

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.ThreeOfAKind);
        }

        [TestMethod]
        public void GetHandTypeDetectsStraight()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 5), 
                new Card(Suit.Diamonds, 6), new Card(Suit.Clubs, 7), 
                new Card(Suit.Hearts, 8), new Card(Suit.Spades, 9) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.Straight);
        }

        [TestMethod]
        public void GetHandTypeDetectsStraightFlush()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 5), 
                new Card(Suit.Clubs, 6), new Card(Suit.Clubs, 7), 
                new Card(Suit.Clubs, 8), new Card(Suit.Clubs, 9) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.StraightFlush);
        }

        [TestMethod]
        public void GetHandTypeDetectsFlush()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 5), 
                new Card(Suit.Clubs, 7), new Card(Suit.Clubs, 10), 
                new Card(Suit.Clubs, 2), new Card(Suit.Clubs, 13) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.Flush);
        }

        [TestMethod]
        public void GetHandTypeDetectsFullHouse()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 5), 
                new Card(Suit.Diamonds, 5), new Card(Suit.Hearts, 5), 
                new Card(Suit.Clubs, 2), new Card(Suit.Spades, 2) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.FullHouse);
        }

        [TestMethod]
        public void GetHandTypeDetectsFourOfAKind()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 5), 
                new Card(Suit.Diamonds, 5), new Card(Suit.Hearts, 5), 
                new Card(Suit.Spades, 5), new Card(Suit.Spades, 2) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.FourofAKind);
        }

        [TestMethod]
        public void GetHandTypeDetectsRoyalFlush()
        {
            var hand = new List<Card>
                { new Card(Suit.Clubs, 12), 
                new Card(Suit.Clubs, 10), new Card(Suit.Clubs, 13), 
                new Card(Suit.Clubs, 11), new Card(Suit.Clubs, 14) };

            
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(HandType.RoyalFlush, handType);
        }

    }
}

