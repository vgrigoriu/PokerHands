namespace PokerHands
{
    public interface IDiscriminatorFactory
    {
        IDiscriminator CreateDiscriminator(HandType handType);
    }
}
