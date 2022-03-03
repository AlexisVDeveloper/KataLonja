using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class TableView : MonoBehaviour, ITableView
{
    [SerializeField] List<CityConfig> cityConfigs;
    [SerializeField] Button calculateBestOptionBtn;

    private TablePresenter _presenter;
    private Action onPressCalculateButton;

    // Start is called before the first frame update
    void Start()
    {
        _presenter = new TablePresenter(this);

        calculateBestOptionBtn.onClick.AddListener(CalculateBestOptionButtonAction);
    }

    private void CalculateBestOptionButtonAction()
    {
        onPressCalculateButton?.Invoke();
    }

    public void SubscribeToButtonEvent(Action callback)
    {
        if (!onPressCalculateButton.GetInvocationList().Contains(callback))
        {
            onPressCalculateButton += callback;
        }
    }

    private void OnDestroy()
    {
        onPressCalculateButton = null;
    }
}
