using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FishInputView : MonoBehaviour
{
    [SerializeField] private Fish fishType;
    [SerializeField] private TMP_InputField value;

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

}
