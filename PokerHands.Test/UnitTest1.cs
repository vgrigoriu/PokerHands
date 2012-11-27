using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokerHands.Exceptions;

namespace PokerHands.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanCreateCard()
        {
            var card = new Card(Suit.Clubs, 7);

            Assert.AreEqual(card.Suit, Suit.Clubs);
            Assert.AreEqual(7, card.Value);
        }

        [TestMethod, ExpectedException(typeof(NotAPokerHandException))]
        public void NumberOfCardsIsValidated()
        {
            List<Card> list1 = new List<Card>() { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            List<Card> list2 = new List<Card>() { new Card(Suit.Spades, 14), 
                new Card(Suit.Diamonds, 10), new Card(Suit.Clubs, 12), 
                new Card(Suit.Hearts, 5) };

            PokerDealer dealer = new PokerDealer();
            int value = dealer.Compare(list1, list2);
        }

        [TestMethod]
        public void HandsWithSameCardValuesAreEqual()
        {
            List<Card> firstHand = new List<Card>() { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            List<Card> secondHand = new List<Card>() { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var value = dealer.Compare(firstHand, secondHand);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void CompareHandWithHigherHandTypeWins()
        {
            List<Card> firstHand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            List<Card> secondHand = new List<Card>() { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var value = new PokerDealer().Compare(firstHand, secondHand);
            Assert.IsTrue(value < 0);
        }

        [TestMethod]
        public void CompareCallsDiscriminatorForEqualHands()
        {
            List<Card> firstHand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            List<Card> secondHand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };
            Mock<IDiscriminator> mockDisc = new Mock<IDiscriminator>();

            var value = new PokerDealer(mockDisc.Object).Compare(firstHand, secondHand);

            mockDisc.Verify(discriminator => discriminator.CompareEqual(firstHand, secondHand));

        }

        [TestMethod]
        public void GetHandTypeDetectsOnePair()
        {
            List<Card> firstHand = new List<Card>() { new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };
            var dealer = new PokerDealer();

            var handType = dealer.GetHandType(firstHand);
            Assert.AreEqual(HandType.OnePair, handType);
        }

        [TestMethod]
        public void GetHandTypeDetectsHighCard()
        {
            List<Card> firstHand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };
            var dealer = new PokerDealer();
            var handtype = dealer.GetHandType(firstHand);
            Assert.AreEqual(handtype, HandType.HighCard);
        }

        [TestMethod]
        public void GetHandTypeDetectsTwoPairs()
        {
            var hand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 2), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.TwoPair);
        }

        [TestMethod]
        public void GetHandTypeDetectsThreeOfAKind()
        {
            var hand = new List<Card>() { new Card(Suit.Clubs, 1), 
                new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var dealer = new PokerDealer();
            var handType = dealer.GetHandType(hand);

            Assert.AreEqual(handType, HandType.ThreeOfAKind);
        }
        // TODO validate arguments (the method should throw ArgumentNullException)

    }
}

