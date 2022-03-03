using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePresenter
{
    private City city;

    private ITableView _view;

    public TablePresenter(ITableView view)
    {
        ConfigureView(view);
        this.city = new City();
    }

    private void ConfigureView(ITableView view)
    {
        _view = view;
        _view.SubscribeToButtonEvent(CalculateBestOption);
    }

    public void CalculateBestOption()
    {

    }

}
