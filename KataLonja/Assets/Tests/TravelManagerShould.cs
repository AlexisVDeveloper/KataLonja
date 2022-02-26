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
    //por cada km recorrido son +2euros 
    //por cada 100km se desvaloriza un 1%

    Dictionary<Fish, int> fishPackage;

    [SetUp]
    public void SetUp()
    {
        fishPackage = new Dictionary<Fish, int>();
        fishPackage.Add(Fish.Vieiras, 50);
        fishPackage.Add(Fish.Pulpo, 100);
        fishPackage.Add(Fish.Centollos, 50);
    }
    
    [Test]
    public void NotSurpassWeightLimit()
    {

        //given
        TravelManager travelManager = new TravelManager(fishPackage);

        //when
        int limitWeight = travelManager.GetWeightLimit();
        int actualWeight = travelManager.GetActualWeight();

        //then

        Assert.True(actualWeight <= limitWeight);
    }

    [Test]
    public void FirstTravel()
    {

    }

}
