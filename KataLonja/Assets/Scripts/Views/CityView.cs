using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CityView : MonoBehaviour
{
    [SerializeField] private CityConfig cityConfig;
    [SerializeField] private FishInputView[] fishInputs;


    void Start()
    {
        foreach (var item in fishInputs)
        {
            item.SetFishValue(cityConfig.marketList.FirstOrDefault(marketObject => marketObject.fishType == item.GetFishType()).price.ToString());
            item.SetInputChangeValue(SetConfigValue);
        }
    }

    private void SetConfigValue(string value, Fish fishtype)
    {
        MarketObject item = cityConfig.marketList.FirstOrDefault(marketObject => marketObject.fishType == fishtype);
        int index = cityConfig.marketList.IndexOf(item);

        int.TryParse(value, out item.price);

        cityConfig.marketList[index] = item;

    }

    public City GetCity()
    {
        City city = new City(cityConfig);

        return city;
    }



}
