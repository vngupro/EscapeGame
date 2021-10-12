using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private PlayerController controller;
    private void Start()
    {
        controller = PlayerController.Instance;
        controller.OnInteract += Interact;
    }

    public void OnDisable()
    {
        controller.OnInteract -= Interact;
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
