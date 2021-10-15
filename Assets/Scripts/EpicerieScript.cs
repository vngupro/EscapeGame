using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EpicerieScript : MonoBehaviour
{
    public TMP_Text textNumber;
    public GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }
    public void ShowNumber(string text)
    {
        textNumber.text = text;
        panel.SetActive(true);
    }
}
