
namespace PokerHands
{
    public class DiscriminatorFactory : IDiscriminatorFactory
    {
        public IDiscriminator CreateDiscriminator(HandType handType)
        {
            switch (handType)
            {
                case HandType.HighCard:
                    return new HighCardDiscriminator();
                case HandType.OnePair:
                    return new TwoPairDiscriminator();
                default:
                    return new HighCardDiscriminator();
            }
        }


    }
}
