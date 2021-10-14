using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BoxCollider))]
public class DoorDetection : MonoBehaviour
{
    #region Event
    public delegate void DoorEvent();
    public event DoorEvent OnTeleport;
    #endregion
    [Title("Assets Only")]
    public GameObject door;
    public GameObject key;
    public GameObject interact;
    [HideInInspector]
    public bool canOpen = false;
    private bool isOpen = false;
    private bool hasKey = false;
    private Animator animator;

    private InventoryManager inventory;
    [HideInInspector]
    public PlayerController controller;
    private void Awake()
    {
        animator = door.GetComponent<Animator>();
        interact.SetActive(false);
    }

    private void Start()
    {
        inventory = InventoryManager.Instance;
        controller = PlayerController.Instance;
        controller.OnInteract += OpenDoor;
    }

    private void OnDisable()
    {
        controller.OnInteract -= OpenDoor;
    }
    [Button]
    public void Init()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void OpenDoor()
    {
        if (canOpen)
        {
            isOpen = true;
            canOpen = false;
            animator.Play("DoorAnimation");
            ItemData data = key.GetComponent<Item>().itemData;
            inventory.RemoveItem(data);

            if(OnTeleport != null)
            {
                OnTeleport();
            }
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
        ItemData data = key.GetComponent<Item>().itemData;
        hasKey = inventory.SearchItem(data);

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
