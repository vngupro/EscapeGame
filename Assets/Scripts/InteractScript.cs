using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private PlayerController controller;
    private MoveScript moveScript;
    private void Start()
    {
        controller = PlayerController.Instance;
        moveScript = MoveScript.Instance;
        controller.OnInteract += Interact;
    }

    public void OnDisable()
    {
        controller.OnInteract -= Interact;
    }

    public void Interact()
    {
        MoveScript.Instance.StopMove();
    }
}
