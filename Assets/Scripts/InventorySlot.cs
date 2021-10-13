using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour
{

    [Header("      UI")]
    public Image image;
    public Button button;
    [Header("       DEBUG")]
    public ItemData itemData;

    [HideInInspector]
    public InventoryManager inventory;

    private void Awake()
    {
        button.onClick.AddListener(OnInventorySlotClick);
    }

    private void OnInventorySlotClick()
    {
        inventory.OpenItem(itemData);
    }

}
