using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WindowDetection : MonoBehaviour
{
    public ItemData key;
    public GameObject interact;

    [HideInInspector]
    public bool canOpen = false;
    private bool isOpen = false;
    private bool hasKey = false;

    private InventoryManager inventory;
    [HideInInspector]
    public PlayerController controller;

    public GameObject qrWindow;
    public GameObject qrPrescription;

    private void Start()
    {
        inventory = InventoryManager.Instance;
        controller = PlayerController.Instance;
        controller.OnInteract += TriggerWindow;
        interact.SetActive(false);
    }
    private void OnDisable()
    {
        controller.OnInteract -= TriggerWindow;
    }
    [Button]
    public void Init()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void TriggerWindow()
    {
        if (isOpen)
        {
            qrWindow.SetActive(false);
            this.gameObject.SetActive(false);
            return;
        }

        if (canOpen)
        {
            isOpen = true;
            canOpen = false;

            inventory.RemoveItem(key);

            SoundManager.Instance.PlaySound("Window");
            qrWindow.SetActive(true);
            qrPrescription.SetActive(true);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isOpen)
            {
                interact.SetActive(true);
                VerifyHasKey();
            }
        }
    }

    private void VerifyHasKey()
    {
        hasKey = inventory.SearchItem(key);

        if (hasKey)
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
            canOpen = false;
        }
    }
}
