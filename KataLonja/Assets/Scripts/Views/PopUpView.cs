using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpView : MonoBehaviour
{
    [SerializeField] private TMP_Text bestOptionText;
    [SerializeField] private Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(HidePopUp);
        HidePopUp();
    }

    public void HidePopUp()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowPopUp()
    {
        this.gameObject.SetActive(true);
    }

    public void SetBestOption(string bestOption)
    {
        bestOptionText.text = bestOption;
    }
}
