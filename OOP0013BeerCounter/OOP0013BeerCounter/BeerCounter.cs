namespace OOP0013BeerCounter
{
    public class BeerCounter
    {
        public static int beerCounter;
        public static int beersDrankCount;

        public BeerCounter()
        {
            beerCounter = 0;
            beersDrankCount = 0;
        }

        public static int BuyBeerCount(int bottlesIn)
        {
            return beerCounter += bottlesIn;
        }

        public static int DrinkBeer(int bottlesOut)
        {
            return beersDrankCount += bottlesOut;
        }
    }
}