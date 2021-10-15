using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CryptexScript : MonoBehaviour
{
    public string secretCode = "4758";
    public TMP_Text textCode;
    public string start = "Entrer Code";
    [TextArea(3,3)]
    public string fail = "Rien ne se passe...";
    [TextArea(3,3)]
    public string success = "Le cryptex s'ouvre : une clé est à l'intérieur !";
    public bool isFirstInput = true;
    public bool hasAlreadyResolve = false;
    public ItemData key;
    private void Awake()
    {
        isFirstInput = true;
        hasAlreadyResolve = false;
        textCode.text = start;
    }

    public void VerifyCode()
    {
        if(textCode.text == secretCode)
        {
            textCode.text = success;
            InventoryManager.Instance.AddItem(key);
            hasAlreadyResolve = true;
        }
        else
        {
            textCode.text = fail;
        }

        isFirstInput = true;
    }

    public void AddNumber(string number)
    {
        if (hasAlreadyResolve) return;
        if (isFirstInput) { 
            textCode.text = "";
            isFirstInput = false;
        }

        textCode.text += number;

        if (textCode.text.Length == 4)
        {
            VerifyCode();
        }
    }
}
