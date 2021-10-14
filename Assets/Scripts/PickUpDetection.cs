using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(ItemData))]
public class PickUpDetection : DetectionScript
{
    public Item item;
    public Image image;
    private bool canPickUp = true;
    public override void Start()
    {
        base.Start();
        PlayerController.Instance.OnInteract += PickUp;
        image.sprite = item.itemData.spriteUI;
        canPickUp = true;
    }
    public void PickUp()
    {
        if (canOpen && canPickUp)
        {
            InventoryManager.Instance.AddItem(item.itemData);
            canPickUp = false;
        }
    }

    public override void TriggerEnigma()
    {
        base.TriggerEnigma();
        if (!isOpen && canOpen)
        {
            this.gameObject.SetActive(false);
        }
    }
    public override void Reset()
    {
        base.Reset();
        image.sprite = item.itemData.sprite;
    }
}
