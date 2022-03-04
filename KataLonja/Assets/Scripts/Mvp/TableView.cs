using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class TableView : MonoBehaviour, ITableView
{
    [SerializeField] private List<CityView> cityViews;
    [SerializeField] private Button calculateBestOptionBtn;
    [SerializeField] private FishInputView[] fishInputs;

    [SerializeField] private PopUpView popUp;

    private TablePresenter _presenter;
    private Action<FishInputView[], List<City>> onPressCalculateButton;

    // Start is called before the first frame update
    void Start()
    {
        _presenter = new TablePresenter(this);

        calculateBestOptionBtn.onClick.AddListener(CalculateBestOptionButtonAction);
    }

    private void CalculateBestOptionButtonAction()
    {
        List<City> cities = cityViews.Select(cityView => cityView.GetCity()).ToList();

        onPressCalculateButton?.Invoke(fishInputs, cities);
    }

    public void SubscribeToButtonEvent(Action<FishInputView[], List<City>> callback)
    {
        onPressCalculateButton += callback;
    }

    public void ShowBestOption(string bestOption)
    {
        popUp.ShowPopUp();
        popUp.SetBestOption(bestOption);
    }

    private void OnDestroy()
    {
        onPressCalculateButton = null;
    }
}
