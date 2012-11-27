using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands.Test
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CanCreateCard()
        {
            var card = new Card(Suit.Clubs, 7);

            Assert.AreEqual(card.Suit, Suit.Clubs);
            Assert.AreEqual(7, card.Value);
        }
    }
}