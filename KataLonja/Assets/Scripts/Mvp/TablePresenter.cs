using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TablePresenter
{
    private ITableView _view;

    public TablePresenter(ITableView view)
    {
        ConfigureView(view);
    }

    private void ConfigureView(ITableView view)
    {
        _view = view;
        _view.SubscribeToButtonEvent(CalculateBestOption);
    }

    public void CalculateBestOption(FishInputView[] fishInputs, List<City> cities)
    {
        Dictionary<Fish, int> fishPackage = fishInputs.ToDictionary(fishInput => fishInput.GetFishType(), fishInput => fishInput.GetValue());

        TravelManager travelManager = new TravelManager(fishPackage);

        _view.ShowBestOption("Nos vamos para" + travelManager.CalculateBestTravelOption(cities).GetCityName());

    }


}
