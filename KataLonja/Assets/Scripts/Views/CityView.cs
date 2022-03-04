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
        }
    }

    public City GetCity()
    {
        City city = new City(cityConfig);

        return city;
    }



}
