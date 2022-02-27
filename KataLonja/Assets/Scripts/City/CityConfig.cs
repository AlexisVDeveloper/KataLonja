using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "City Config/Create New")]
public class CityConfig : ScriptableObject
{
    public string cityName;
    public int cityDistance;
    public List<MarketObject> marketList = new List<MarketObject>();
}

