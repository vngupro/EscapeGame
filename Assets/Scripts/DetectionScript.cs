using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BoxCollider))]
public class DetectionScript : MonoBehaviour
{
    public Canvas canvasInteract;
    public Canvas canvasClue;

    [HideInInspector]
    public bool canOpen = false;
    [HideInInspector]
    public bool isOpen = false;
    [HideInInspector]
    public PlayerController controller;

    [Button]
    public virtual void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        canvasInteract.gameObject.SetActive(false);
    }
    private void Awake()
    {
        canvasInteract.gameObject.SetActive(false);
    }
    public virtual void Start()
    {
        controller = PlayerController.Instance;
        isOpen = false;

        controller.OnInteract += TriggerEnigma;
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        controller.OnInteract -= TriggerEnigma;
    }

    public virtual void TriggerEnigma()
    {
        if (canOpen)
        {
            isOpen = !isOpen;
            canvasClue.gameObject.SetActive(isOpen);
            
            MoveScript.Instance.canMove = !isOpen;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            canvasInteract.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            canvasInteract.gameObject.SetActive(false);
        }
    }

    public void CloseCanvas()
    {
        isOpen = false;
    }
}
