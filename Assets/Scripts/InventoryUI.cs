using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public GameObject grid;
    public GameObject panel;
    public Image image;
    private List<GameObject> slotsUI = new List<GameObject>();
    [HideInInspector]
    public bool isOpen = false;
    
    private void Awake()
    {
        isOpen = false;
    }

    public void ShowItem(ItemData data)
    {
        panel.SetActive(true);
        image.sprite = data.spriteUI;
        isOpen = true;
    }

    public void AddItemUI(GameObject newSlot)
    {
        slotsUI.Add(newSlot);
    }
    public void RemoveItemUIAtIndex(int index)
    {
        Destroy(slotsUI[index]);
        slotsUI.RemoveAt(index);
    }
}
