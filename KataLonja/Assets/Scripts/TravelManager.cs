using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TravelManager
{
    private const int MAXWEIGHT = 200;
    private Dictionary<Fish, int> fishPackage;

    private int actualWeight;

    public TravelManager(Dictionary<Fish,int> fishPackage)
    {
        this.fishPackage = fishPackage;
        this.actualWeight = fishPackage.Aggregate(this.actualWeight, (weight, fish) => (weight + fish.Value));
    }

    public int GetWeightLimit()
    {
        return MAXWEIGHT;
    }

    public int GetActualWeight()
    {
        return this.actualWeight;
    }

    public int CalculateBaseTravelCost(City city) 
    {
        Dictionary<Fish, int> cityCostMarket = city.GetFishCostMarket();

        

        return 0;
    }
}
