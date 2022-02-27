using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TravelManagerShould
{
    //Maximo de viaje 200kg
    //Primer viaje 50kg de vieras, 100kg pulpo y 50kg de centollos

    //5 euros para cargar la furgoneta
    //por cada km recorrido son +2 en euros 
    //por cada 100km se desvaloriza un 1%

    private Dictionary<Fish, int> fishPackage;
    private TravelManager travelManager;
    private City madridDummy;
    private City barcelonaDummy;
    private City lisboaDummy;
    private const int expectedBaseCost = 47500;
    private const int expectedTotalCost = 52905;

    [SetUp]
    public void SetUp()
    {
        fishPackage = new Dictionary<Fish, int>();
        fishPackage.Add(Fish.Vieiras, 50);
        fishPackage.Add(Fish.Pulpo, 100);
        fishPackage.Add(Fish.Centollos, 50);

        travelManager = new TravelManager(fishPackage);

        CityConfig madridFakeConfig = ScriptableObject.CreateInstance<CityConfig>();
        madridFakeConfig.marketList.Add(new MarketObject(Fish.Vieiras, 500));
        madridFakeConfig.marketList.Add(new MarketObject(Fish.Pulpo, 0));
        madridFakeConfig.marketList.Add(new MarketObject(Fish.Centollos, 450));
        madridFakeConfig.cityDistance = 800;
        madridFakeConfig.cityName = "Madrid";

        CityConfig lisboaFakeConfig = ScriptableObject.CreateInstance<CityConfig>();
        lisboaFakeConfig.marketList.Add(new MarketObject(Fish.Vieiras, 600));
        lisboaFakeConfig.marketList.Add(new MarketObject(Fish.Pulpo, 100));
        lisboaFakeConfig.marketList.Add(new MarketObject(Fish.Centollos, 500));
        lisboaFakeConfig.cityDistance = 800;
        lisboaFakeConfig.cityName = "Lisboa";

        CityConfig barcelonaFakeConfig = ScriptableObject.CreateInstance<CityConfig>();
        barcelonaFakeConfig.marketList.Add(new MarketObject(Fish.Vieiras, 450));
        barcelonaFakeConfig.marketList.Add(new MarketObject(Fish.Pulpo, 120));
        barcelonaFakeConfig.marketList.Add(new MarketObject(Fish.Centollos, 0));
        barcelonaFakeConfig.cityDistance = 800;
        barcelonaFakeConfig.cityName = "Barcelona";

        madridDummy = new City(madridFakeConfig);
        barcelonaDummy = new City(barcelonaFakeConfig);
        lisboaDummy = new City(lisboaFakeConfig);
    }
    
    [Test]
    public void NotSurpassWeightLimit()
    {
        //when
        int limitWeight = travelManager.GetWeightLimit();
        int actualWeight = travelManager.GetActualWeight();

        //then
        Assert.True(actualWeight <= limitWeight);
    }

    [Test]
    public void ReturnBaseTravelCost()
    {
        int madridCost = travelManager.CalculateBaseTravelCost(madridDummy);

        Assert.GreaterOrEqual(madridCost, expectedBaseCost);
    }

    [Test]
    public void ReturnTotalTravelCost() 
    {
        int madridCost = travelManager.CalculateTotalTravelCost(madridDummy);

        Assert.GreaterOrEqual(madridCost, expectedTotalCost);
    }

    [Test]
    public void CalculateBestOption() 
    {
        List<City> cities = new List<City> {
            madridDummy,
            lisboaDummy,
            barcelonaDummy
        };

        City bestOption = travelManager.CalculateBestTravelOption(cities);

        Assert.AreEqual(barcelonaDummy.GetCityName(), bestOption.GetCityName());
    }
}
