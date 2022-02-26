using System.Collections.Generic;

public class City
{
    private Dictionary<Fish,int> fishCostMarket;
    private int cityDistance;

    public City() 
    {
        fishCostMarket = new Dictionary<Fish, int>();

        fishCostMarket.Add(Fish.Vieiras, 500);
        fishCostMarket.Add(Fish.Pulpo, 0);
        fishCostMarket.Add(Fish.Centollos, 450);
    }

    public Dictionary<Fish,int> GetFishCostMarket() 
    {
        return fishCostMarket;
    }
}
