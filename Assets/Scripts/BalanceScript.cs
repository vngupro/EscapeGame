using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BalanceScript : MonoBehaviour
{
    public string code_1 = "3";
    public string code_2 = "7";
    public string code_3 = "8";
    public string code_4 = "1";

    public List<WeightScript> weights = new List<WeightScript>();
    public List<TMP_Text> weightsText = new List<TMP_Text>();
    public List<Image> weightsSprite = new List<Image>();
    public List<WeightScript> optionsWeights = new List<WeightScript>();

    private int currentIndex;
    private int count = 0;
    private bool hasCode_1 = false;
    private bool hasCode_2 = false;
    private bool hasCode_3 = false;
    private bool hasCode_4 = false;
    private bool hasFoundCode = false;

    public GameObject qrCodePanel;
    public GameObject panelUp;
    public GameObject panelDown;

    public GameObject triggerKey02;

    private void Start()
    {
        foreach(WeightScript weight in weights)
        {
            weight.gameObject.SetActive(false);
        }
        qrCodePanel.SetActive(false);
        panelDown.SetActive(true);
        panelUp.SetActive(true);
        triggerKey02.SetActive(false);
    }
    public void AddWeightNumber(string number)
    {
        if(hasFoundCode) { return; }
        if (count == 4) {
            foreach(WeightScript weight in weights)
            {
                PutDownWeight(weight);
                weight.gameObject.SetActive(false);
                weight.number = "";
                weight.sprite = null;
                hasCode_1 = false;
                hasCode_2 = false;
                hasCode_3 = false;
                hasCode_4 = false;
            }

            count = 0;
        }

        for(int i = 0; i < weights.Count; i++)
        {
            if (!weights[i].gameObject.activeInHierarchy)
            {
                weightsText[i].text = number;
                weights[i].number = number;
                currentIndex = i;
                weights[i].gameObject.SetActive(true);
                count++;
                break;
            }
        }

        // Verify if code is good
       if(count == 4)
        {
            Debug.Log(count);
            foreach(WeightScript weight in weights)
            {
                if(weight.number == code_1 && !hasCode_1)
                {
                    hasCode_1 = true;
                }
                else if(weight.number == code_2 && !hasCode_2)
                {
                    hasCode_2 = true;
                }else if(weight.number == code_3 && !hasCode_3)
                {
                    hasCode_3 = true;
                }
                else if(weight.number == code_4 && !hasCode_4)
                {
                    hasCode_4 = true;
                }
            }

            if(hasCode_1 && hasCode_2 && hasCode_3 && hasCode_4)
            {
                ShowQRCode();
                triggerKey02.SetActive(true);
            }
        }
    }

    public void ShowQRCode()
    {
        qrCodePanel.SetActive(true);
        panelDown.SetActive(false);
        panelUp.SetActive(false);
    }
    public void ChangeSprite(Sprite sprite)
    {
        if (hasFoundCode) { return; }
        weightsSprite[currentIndex].sprite = sprite;
        weights[currentIndex].sprite = sprite;
    }

    public void PutDownWeight(WeightScript weight)
    {
        foreach(WeightScript option in optionsWeights)
        {
            if(weight.number == option.number && 
                weight.sprite == option.sprite)
            {
                option.gameObject.SetActive(true);
                count--;
            }
        }
    }
}
