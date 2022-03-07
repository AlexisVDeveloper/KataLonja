using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class FishInputView : MonoBehaviour
{
    [SerializeField] private Fish fishType;
    [SerializeField] private TMP_InputField value;

    private UnityAction<string, Fish> onChangeValue;

    public int GetValue()
    {
        int result = 0;

        int.TryParse(value.text, out result);

        return result;
    }

    public Fish GetFishType()
    {
        return fishType;
    }

    public void SetFishValue(string value)
    {
        this.value.text = value;
    }

    public void SetInputChangeValue(UnityAction<string, Fish> onChangeValue)
    {
        this.onChangeValue = onChangeValue;

        value.onValueChanged.AddListener(InputChangeValueAction);
    }

    private void InputChangeValueAction(string value)
    {
        this.onChangeValue(value, fishType);
    }

}
