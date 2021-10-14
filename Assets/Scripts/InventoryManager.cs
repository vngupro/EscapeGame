using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InventoryManager : MonoBehaviour
{
    public InventoryUI ui;
    [Title("Asset Only")]    
    public GameObject slotPrefab;

    [Header("      DEBUG")]
    public List<InventorySlot> slots = new List<InventorySlot>();

    private PlayerController controller;
    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;

  
    }
    private void Start()
    {
        PlayerController.Instance.OnInventory += TriggerPanel;
    }
    public void AddItem(ItemData data)
    {
        GameObject newSlot = Instantiate(slotPrefab, ui.grid.transform);
        ui.AddItemUI(newSlot);
        InventorySlot slot = newSlot.GetComponent<InventorySlot>();
        slot.itemData = data;
        slot.image.sprite = data.spriteSlot;
        slot.inventory = this;
        slots.Add(slot);
    }

    public void OpenItem(ItemData data)
    {
        ui.ShowItem(data);
    }
    public void RemoveItem(ItemData data)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemData == data)
            {
                slots.RemoveAt(i);
                ui.RemoveItemUIAtIndex(i);
            }
        }
    }
    public bool SearchItem(ItemData data)
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if(slots[i].itemData == data)
            {
                return true;
            }
        }
        return false;
    }
    public void TriggerPanel()
    {
        if(slots[0] != null)
        {
            ui.isOpen = !ui.isOpen;
            ui.panel.SetActive(ui.isOpen);
            ui.image.sprite = slots[0].itemData.spriteUI;
        }
    }
}
