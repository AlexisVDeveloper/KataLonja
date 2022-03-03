using System.Collections.Generic;

public class City
{
    private List<MarketObject> fishCostMarket;
    private int cityDistance;
    private string cityName;

    public City(CityConfig config)
    {
        fishCostMarket = config.marketList;
        cityDistance = config.cityDistance;
        cityName = config.cityName;
    }

    public City() { }

    public string GetCityName()
    {
        return cityName;
    }

    public List<MarketObject> GetFishCostMarket()
    {
        return fishCostMarket;
    }

    public int GetCityDistance()
    {
        return cityDistance;
    }
}
