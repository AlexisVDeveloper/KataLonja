using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TravelManager
{
    private const int MAXWEIGHT = 200;
    private const int TRUCK_COST = 5;
    private const int KM_COST = 2;
    private const int MAX_DISTANCE_DEVALUE = 100;
    private Dictionary<Fish, int> fishPackage;
    private int actualWeight;


    public TravelManager(Dictionary<Fish, int> fishPackage)
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
        List<MarketObject> cityCostMarket = city.GetFishCostMarket();

        int result = 0;

        foreach (var marketObject in cityCostMarket)
        {
            result += marketObject.price * fishPackage[marketObject.fishType];
        }

        return result;
    }

    public int CalculateTotalTravelCost(City city)
    {
        int baseCost = CalculateBaseTravelCost(city);

        int cityDistance = city.GetCityDistance();

        int devaluePercent = cityDistance / MAX_DISTANCE_DEVALUE;

        int totalPrice = baseCost;

        totalPrice -= TRUCK_COST;

        totalPrice -= KM_COST * cityDistance;

        totalPrice -= (baseCost * devaluePercent) / 100;

        return totalPrice;
    }

    public City CalculateBestTravelOption(List<City> cities)
    {
        City bestOption = cities.OrderByDescending(city => CalculateTotalTravelCost(city)).First();
        return bestOption;
    }
}
