using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PokerHands.Test
{
    [TestClass]
    public class DiscriminatorTests
    {
        [TestMethod]
        public void CompareHandCallsDiscriminatorFactory()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                    new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                    new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var secondHand = new List<Card>
                { new Card(Suit.Clubs, 2), 
                    new Card(Suit.Diamonds, 3), new Card(Suit.Clubs, 2), 
                    new Card(Suit.Hearts, 11), new Card(Suit.Spades, 12) };

            var discriminatorFactoryMock = new Mock<IDiscriminatorFactory>();
            var discriminatorStub = new Mock<IDiscriminator>();

            discriminatorFactoryMock.Setup(df => df.CreateDiscriminator(It.IsAny<HandType>())).
                Returns(discriminatorStub.Object);
            var dealer = new PokerDealer(discriminatorFactoryMock.Object);
            dealer.GetWinner(firstHand, secondHand);

            discriminatorFactoryMock.Verify(df => df.CreateDiscriminator(HandType.OnePair));
        }

        [TestMethod]
        public void CompareCallsDiscriminatorForEqualHands()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                    new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var secondHand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 1), new Card(Suit.Clubs, 1), 
                    new Card(Suit.Hearts, 2), new Card(Suit.Spades, 7) };

            var mockDiscriminator = new Mock<IDiscriminator>();
            var stubDiscriminatorFactory = new Mock<IDiscriminatorFactory>();
            stubDiscriminatorFactory
                .Setup(df => df.CreateDiscriminator(HandType.ThreeOfAKind))
                .Returns(mockDiscriminator.Object);

            new PokerDealer(stubDiscriminatorFactory.Object)
                .GetWinner(firstHand, secondHand);

            mockDiscriminator.Verify(
                d => d.GetWinnerForHandsWithSameType(
                    It.IsAny<IList<Card>>(),
                    It.IsAny<IList<Card>>()));
        }

        [TestMethod]
        public void CompareEqualDiscriminatesHighCardHands()
        {
            var firstHand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 5), new Card(Suit.Clubs, 3), 
                    new Card(Suit.Hearts, 2), new Card(Suit.Spades, 12) };

            var secondHand = new List<Card>
                { new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 6), new Card(Suit.Clubs, 9), 
                    new Card(Suit.Hearts, 2), new Card(Suit.Spades, 7) };

            var discriminatorFactory = new DiscriminatorFactory();
            var discriminator = discriminatorFactory.CreateDiscriminator(HandType.HighCard);

            var result = discriminator.GetWinnerForHandsWithSameType(firstHand, secondHand);

            Assert.AreEqual(Winner.First, result);
        }

        [TestMethod]
        public void CompareEqualDiscriminatesOnePairHands()
        {
            var firstHand = new List<Card>
            {
                new Card(Suit.Hearts, 2),
                new Card(Suit.Clubs, 2), 
                new Card(Suit.Diamonds, 1),
                new Card(Suit.Clubs, 3), 
                new Card(Suit.Spades, 12),
            };

            var secondHand = new List<Card>
            {
                new Card(Suit.Diamonds, 3),
                new Card(Suit.Hearts, 3),
                new Card(Suit.Clubs, 1), 
                new Card(Suit.Spades, 7),
                new Card(Suit.Clubs, 9), 
            };

            var discriminatorFactory = new DiscriminatorFactory();
            var discriminator = discriminatorFactory.CreateDiscriminator(HandType.OnePair);

            var result = discriminator.GetWinnerForHandsWithSameType(firstHand, secondHand);

            Assert.AreEqual(Winner.Second, result);
        }

        [TestMethod]
        public void CompareEqualDiscriminatesHighCardHandsBySecondCard()
        {
            var firstHand = new List<Card>
                { 
                    new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 5),
                    new Card(Suit.Clubs, 3), 
                    new Card(Suit.Hearts, 2),
                    new Card(Suit.Spades, 12)
                };

            var secondHand = new List<Card>
                {
                    new Card(Suit.Clubs, 1), 
                    new Card(Suit.Diamonds, 6),
                    new Card(Suit.Clubs, 9), 
                    new Card(Suit.Hearts, 12),
                    new Card(Suit.Spades, 7)
                };

            var discriminatorFactory = new DiscriminatorFactory();
            var discriminator = discriminatorFactory.CreateDiscriminator(HandType.HighCard);

            var result = discriminator.GetWinnerForHandsWithSameType(firstHand, secondHand);

            Assert.AreEqual(Winner.Second, result);
        }
    }
}
