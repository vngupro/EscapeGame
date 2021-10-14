using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchQR : MonoBehaviour
{
    public ItemData lunette;
    public GameObject qr2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager inventory = other.GetComponent<InventoryManager>();
            if (inventory.SearchItem(lunette))
            {
                qr2.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
