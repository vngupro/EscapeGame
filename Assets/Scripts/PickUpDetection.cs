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

            if(item.itemData.name == "Key_001" || 
                item.itemData.name == "Key_002" || 
                item.itemData.name == "Key_003" || 
                item.itemData.name == "Chrysantheme")
            {
                SoundManager.Instance.PlaySound("Key");
            }
            else if(item.itemData.name == "Photo")
            {
                SoundManager.Instance.PlaySound("Paper");
            }
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
