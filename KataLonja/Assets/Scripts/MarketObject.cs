using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarketObject 
{
    public Fish fishType;
    public int price;

    public MarketObject(Fish fishType, int price)
    {
        this.fishType = fishType;
        this.price = price;
    }
}